using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderControl : MonoBehaviour
{
    [SerializeField] private GameObject flameThrowSkill;
    [SerializeField] private Material placebleMat;
    [SerializeField] private Material notPlacebleMat;
    private SkinnedMeshRenderer clothes;

    private void Start()
    {
        clothes = transform.Find("RiggedCharacter").transform.Find("Cult Leader").GetComponent<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(flameThrowSkill, transform.Find("FlameThrowPoint").transform);
            Debug.Log("alo");
        }
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
