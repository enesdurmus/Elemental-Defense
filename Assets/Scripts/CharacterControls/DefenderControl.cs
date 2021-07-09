using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderControl : MonoBehaviour
{

    [SerializeField] private Material placebleMat;
    [SerializeField] private Material notPlacebleMat;
    private SkinnedMeshRenderer clothes;

    private void Start()
    {
        clothes = transform.Find("RiggedCharacter").transform.Find("Cult Leader").GetComponent<SkinnedMeshRenderer>();
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
