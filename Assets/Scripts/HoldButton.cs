using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class HoldButton : Button
{
    GameObject gameControl;

    protected override void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("GameController");
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        gameControl.GetComponent<PlaceDefender>().CreateDefender();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        gameControl.GetComponent<PlaceDefender>().Place();
    }
}
