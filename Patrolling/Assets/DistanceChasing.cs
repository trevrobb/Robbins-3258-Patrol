using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceChasing : MonoBehaviour
{
    GameObject Player;
    NavMeshAgent agent;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, Player.transform.position));
        if (Vector3.Distance(transform.position, Player.transform.position) < 110f)
        {
            agent.SetDestination(Player.transform.position);
        }
    }
}
