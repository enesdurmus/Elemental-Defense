using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderControl : MonoBehaviour
{
    private enum DefenderType { Sprayer, Thrower, Stormer };
    private DefenderType defenderType;

    private GameObject spraySkillPrefab;
    private GameObject throwSkillPrefab;
    private GameObject stormSkillPrefab;

    [SerializeField] private Material placebleMat;
    [SerializeField] private Material notPlacebleMat;

    private GameObject target;

    private GameObject defenderSkill;
    private bool isTargetSet = false;
    private bool isPlaced = false;
    private bool canThrow = true;

    private SkinnedMeshRenderer clothes;

    private void Start()
    {
        clothes = transform.Find("RiggedCharacter").transform.Find("Cult Leader").GetComponent<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        if (isTargetSet)
        {
            switch (defenderType)
            {
                case DefenderType.Sprayer:
                    ExecuteSpraySkill();
                    break;
                case DefenderType.Thrower:
                    if (canThrow)
                    {
                        ExecuteThrowSkill();
                    }
                    break;
                case DefenderType.Stormer:
                    break;
            }
        }
    }

    public void SetSkills(GameObject spraySkillPrefab, GameObject throwSkillPrefab, GameObject stormSkillPrefab)
    {
        this.spraySkillPrefab = spraySkillPrefab;
        this.throwSkillPrefab = throwSkillPrefab;
        this.stormSkillPrefab = stormSkillPrefab;
        isPlaced = true;
    }

    private void ExecuteSpraySkill()
    {
        transform.LookAt(target.transform);
        ParticleSystem.MainModule ps = defenderSkill.GetComponent<ParticleSystem>().main;
        ps.startSpeed = Vector3.Distance(transform.position, target.transform.position);
    }

    private void ExecuteThrowSkill()
    {
        transform.LookAt(target.transform);
        defenderSkill.GetComponent<BallControl>().Throw(target, defenderSkill);
        defenderSkill = null;
        StartCoroutine(ThrowAgainCounter());
    }

    public void SetTarget(GameObject target)
    {
        if (isPlaced)
        {
            if (!isTargetSet)
            {
                switch (defenderType)
                {
                    case DefenderType.Sprayer:
                        defenderSkill = Instantiate(spraySkillPrefab, transform.Find("FlameThrowPoint").transform);
                        break;
                    case DefenderType.Thrower:
                        defenderSkill = Instantiate(throwSkillPrefab, transform.Find("FlameThrowPoint").transform);
                        break;
                    case DefenderType.Stormer:
                        defenderSkill = Instantiate(stormSkillPrefab, transform.Find("FlameThrowPoint").transform);
                        break;
                }

                this.target = target;
                isTargetSet = true;
            }
        }
    }

    public void SetDefenderType(string defenderType)
    {
        if (defenderType.Equals("Sprayer"))
        {
            this.defenderType = DefenderType.Sprayer;
        }
        else if (defenderType.Equals("Thrower"))
        {
            this.defenderType = DefenderType.Thrower;
        }
    }

    IEnumerator ThrowAgainCounter()
    {
        canThrow = false;
        yield return new WaitForSeconds(3);
        if (this.target != null)
        {
            defenderSkill = Instantiate(throwSkillPrefab, transform.Find("FlameThrowPoint").transform);
        }
        canThrow = true;
    }

    public void ClearTarget()
    {
        isTargetSet = false;
        Destroy(defenderSkill);
        this.target = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.CompareTag("PlacementArea"))
        {
            clothes.material = placebleMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.gameObject.CompareTag("PlacementArea"))
        {
            clothes.material = notPlacebleMat;
        }
    }
}
