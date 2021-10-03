using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameControl : MonoBehaviour
{
    [SerializeField] Animator sideMenuAnimator;
    [SerializeField] GameObject timerGameObject;

    private TMP_Text timer;

    private string elementalType;
    public bool isGameRunning = false;

    private int placementTime = 15;
    private int time;

    void Start()
    {
        timer = timerGameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {

    }

    public void SetElementalType(string type)
    {
        elementalType = type;
        sideMenuAnimator.SetBool("Selected", true);
        StartCoroutine(PlacementCounter());
    }

    public string GetElementalType()
    {
        return elementalType;
    }

    private void SetTimer(int time)
    {
        timer.SetText(time.ToString());
    }

    IEnumerator PlacementCounter()
    {
        time = placementTime;
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time -= 1;
            SetTimer(time);
        }
        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        time = 0;
        isGameRunning = true;
        while (isGameRunning)
        {
            yield return new WaitForSeconds(1);
            time += 1;
            SetTimer(time);
        }
    }
}
