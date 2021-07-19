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

    private float zOffSet = 20f;


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
        temp.z = zOffSet + (Input.mousePosition.y / 180);
        defender.transform.position = Camera.main.ScreenToWorldPoint(temp);
        defender.transform.position = new Vector3(defender.transform.position.x, 0f, defender.transform.position.z);
    }

    public void Place(string defenderType)
    {
        if(defender.transform.Find("RiggedCharacter").transform.Find("Cult Leader").GetComponent<SkinnedMeshRenderer>().material.name == "PlacebleMaterial (Instance)")
        {
            defender.transform.position = new Vector3(defender.transform.position.x, 0f, defender.transform.position.z);
            defender.GetComponent<DefenderControl>().SetDefenderType(defenderType);
            string elementalType = GetComponent<GameControl>().GetElementalType();

            if (elementalType.Equals("Fire"))
            {
                defender.GetComponent<DefenderControl>().SetSkills(fireSpraySkillPrefab, fireThrowSkillPrefab, fireStormSkillPrefab);
            }
            else if (elementalType.Equals("Water"))
            {
                defender.GetComponent<DefenderControl>().SetSkills(waterSpraySkillPrefab, waterThrowSkillPrefab, waterStormSkillPrefab);
            }
            else if (elementalType.Equals("Earth"))
            {
                defender.GetComponent<DefenderControl>().SetSkills(earthSpraySkillPrefab, earthSpraySkillPrefab, earthSpraySkillPrefab);
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
