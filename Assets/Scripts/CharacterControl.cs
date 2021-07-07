using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
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
        clothes.material = placebleMat;
    }

    private void OnTriggerExit(Collider other)
    {
        clothes.material = notPlacebleMat;
    }
}
