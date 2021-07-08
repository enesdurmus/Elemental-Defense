using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackerControl : MonoBehaviour
{
    private GameObject reachPoint;

    void Start()
    {
        reachPoint = GameObject.FindGameObjectWithTag("ReachPoint");
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = reachPoint.transform.position;
    }
}
