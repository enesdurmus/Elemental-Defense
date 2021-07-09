using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDefender : MonoBehaviour
{

    [SerializeField] private GameObject defenderPrefab;
    private GameObject defender;
    private bool defenderCreated = false;

    private void Update()
    {
        if (defenderCreated)
        {
            DragDefender();
        }
    }

    public void CreateDefender()
    {
        defenderCreated = true;
        defender = Instantiate(defenderPrefab);
        defender.transform.position.Set(0f, 0f, 0f);
    }

    public void DragDefender()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = 28.6f + (Input.mousePosition.y / 120);
        temp.x -= 15f;
        defender.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }

    public void Place()
    {
        if(defender.transform.Find("RiggedCharacter").transform.Find("Cult Leader").GetComponent<SkinnedMeshRenderer>().material.name == "PlacebleMaterial (Instance)")
        {
            defender.transform.position = new Vector3(defender.transform.position.x, 0f, defender.transform.position.z);
            defenderCreated = false;
        }
        else
        {
            defenderCreated = false;
            Destroy(defender);
        }
    }
}
