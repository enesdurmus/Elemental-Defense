using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private enum ElementalType { Fire, Earth, Water };
    private ElementalType elementalType;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetElementalType(string type)
    {
        if (type.Equals("Fire"))
        {
            elementalType = ElementalType.Fire;
        }
        else if (type.Equals("Earth"))
        {
            elementalType = ElementalType.Earth;
        }
        else if (type.Equals("Water"))
        {
            elementalType = ElementalType.Water;
        }
    }
}
