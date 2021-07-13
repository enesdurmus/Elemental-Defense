using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    private GameObject target;
    private GameObject defenderSkill;

    private void Update()
    {
        if(target != null)
        {
            ExecuteThrow();
        }
    }

    public void Throw(GameObject target, GameObject defenderSkill)
    {
        this.target = target;
        this.defenderSkill = defenderSkill;
    }

    private void ExecuteThrow()
    {
        transform.LookAt(target.transform);
        Vector3 directionToMove = target.transform.position - transform.position;
        directionToMove = directionToMove.normalized * Time.deltaTime * 10f;
        float maxDistance = Vector3.Distance(transform.position, target.transform.position);
        defenderSkill.transform.position = defenderSkill.transform.position + Vector3.ClampMagnitude(directionToMove, maxDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "RiggedCharacter")
        {
            GetComponent<ParticleSystem>().Stop();
            Instantiate(explosionPrefab, transform);
            StartCoroutine(DestroyAfterExplosion());
        }
    }

    IEnumerator DestroyAfterExplosion()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
