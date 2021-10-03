using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class HoldButton : Button
{
    GameControl gameControl;

    protected override void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (!gameControl.isGameRunning)
        {
            gameControl.GetComponent<PlaceDefender>().CreateDefender();
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Client client = new Client();
        if (!gameControl.isGameRunning)
        {
            gameControl.GetComponent<PlaceDefender>().Place(transform.name);
        }
    }
}
