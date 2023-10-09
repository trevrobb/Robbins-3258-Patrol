using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPath : MonoBehaviour
{
    [SerializeField] Transform[] controlPoints;
    int currentPoint;
    [SerializeField] NavMeshAgent agent;

    bool visionCone;
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
            
            currentPoint = Random.Range(0, 8);
            
            
            agent.SetDestination(controlPoints[currentPoint].position);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }
}
