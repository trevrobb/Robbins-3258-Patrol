using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceChasing : MonoBehaviour
{
    GameObject Player;
    NavMeshAgent agent;
    bool chaseThePlayer;
    bool doneChecking;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        chaseThePlayer = false;
        doneChecking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, Player.transform.position));
        if (Vector3.Distance(transform.position, Player.transform.position) < 110f && !doneChecking)
        {
            chaseThePlayer = true;
            
        }
        if (chaseThePlayer)
        {
            agent.SetDestination(Player.transform.position);
        }
    }
}
