using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDefender : MonoBehaviour
{

    [SerializeField] private GameObject defenderPrefab;
    [SerializeField] private GameObject fireSpraySkillPrefab;
    [SerializeField] private GameObject fireThrowSkillPrefab;
    [SerializeField] private GameObject fireStormSkillPrefab;
    [SerializeField] private GameObject earthSpraySkillPrefab;
    [SerializeField] private GameObject earthThrowSkillPrefab;
    [SerializeField] private GameObject earthStormSkillPrefab;
    [SerializeField] private GameObject waterSpraySkillPrefab;
    [SerializeField] private GameObject waterThrowSkillPrefab;
    [SerializeField] private GameObject waterStormSkillPrefab;

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
    }

    public void DragDefender()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = 24.6f + (Input.mousePosition.y / 120);
        temp.x -= 15f;
        defender.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }

    public void Place(string defenderType)
    {
        if(defender.transform.Find("RiggedCharacter").transform.Find("Cult Leader").GetComponent<SkinnedMeshRenderer>().material.name == "PlacebleMaterial (Instance)")
        {
            defender.transform.position = new Vector3(defender.transform.position.x, 0f, defender.transform.position.z);
            defender.GetComponent<DefenderControl>().SetDefenderType(defenderType);
            defender.transform.position.Set(0f, 0f, 0f);
            string elementalType = GetComponent<GameControl>().GetElementalType();
            if (elementalType.Equals("Fire"))
            {
                defender.GetComponent<DefenderControl>().SetSkills(fireSpraySkillPrefab, fireThrowSkillPrefab, fireStormSkillPrefab);
            }
            else if (elementalType.Equals("Water"))
            {
                defender.GetComponent<DefenderControl>().SetSkills(waterSpraySkillPrefab, waterThrowSkillPrefab, waterStormSkillPrefab);
            }
            defenderCreated = false;
        }
        else
        {
            defenderCreated = false;
            Destroy(defender);
        }
    }
}
