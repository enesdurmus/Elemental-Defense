using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private string elementalType;
    [SerializeField] Animator sideMenuAnimator;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SetElementalType(string type)
    {
        elementalType = type;
        sideMenuAnimator.SetBool("Selected", true);

    }

    public string GetElementalType()
    {
        return elementalType;
    }
}
