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
        defender.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, Input.mousePosition.y));
        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, Input.mousePosition.y)));
    }

    public void Place()
    {
        defenderCreated = false;
    }
}
