using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderControl : MonoBehaviour
{
    private enum DefenderType { Sprayer, Thrower, Stormer };
    private DefenderType defenderType = DefenderType.Thrower;

    [SerializeField] private GameObject spraySkillPrefab;
    [SerializeField] private GameObject throwSkillPrefab;
    [SerializeField] private GameObject stormSkillPrefab;


    [SerializeField] private Material placebleMat;
    [SerializeField] private Material notPlacebleMat;

    private GameObject target;

    private GameObject defenderSkill;
    private bool isTargetSet = false;

    private SkinnedMeshRenderer clothes;

    private void Start()
    {
        clothes = transform.Find("RiggedCharacter").transform.Find("Cult Leader").GetComponent<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        if (isTargetSet)
        {
            switch (defenderType) {
                case DefenderType.Sprayer:
                    ExecuteSpraySkill();
                    break;
                case DefenderType.Thrower:
                    ExecuteThrowSkill();
                    break;
                case DefenderType.Stormer:
                    break;
            }
        }
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
        Vector3 directionToMove = target.transform.position - transform.position;      
        directionToMove = directionToMove.normalized * Time.deltaTime * 10f;
        //float maxDistance = Vector3.Distance(transform.position, target.transform.position);
        //defenderSkill.transform.position = defenderSkill.transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);
        defenderSkill.transform.position = defenderSkill.transform.position + directionToMove;

    }

    public void SetTarget(GameObject target)
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
