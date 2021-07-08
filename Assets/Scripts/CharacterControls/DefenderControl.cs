using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderControl : MonoBehaviour
{

    [SerializeField] private Material placebleMat;
    [SerializeField] private Material notPlacebleMat;
    private MeshRenderer clothes;

    private void Start()
    {
        clothes = transform.Find("Player").transform.Find("Robe").GetComponent<MeshRenderer>();
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
