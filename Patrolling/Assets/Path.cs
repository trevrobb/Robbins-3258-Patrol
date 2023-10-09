using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] controlPoints;
    int currentPoint;
    [SerializeField] NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(controlPoints[0].position);
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < .1f)
        {
            if (currentPoint == controlPoints.Length -1)
            {
                currentPoint = 0;
            }
            else{
                currentPoint = 1;
            }
            agent.SetDestination(controlPoints[currentPoint].position);
            
        }
    }
}
