using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private string elementalType;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetElementalType(string type)
    {
        elementalType = type;
    }

    public string GetElementalType()
    {
        return "Water";
    }
}
