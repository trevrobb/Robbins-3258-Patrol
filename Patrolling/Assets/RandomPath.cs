using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPath : MonoBehaviour
{
    [SerializeField] Transform[] controlPoints;
    int currentPoint;
    [SerializeField] NavMeshAgent agent;
    public static RandomPath instance;
    public bool visionCone;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(controlPoints[0].position);
        currentPoint = 0;

        instance = this;
        visionCone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!visionCone)
        {

        
        if (agent.remainingDistance < .1f)
        {
            
            currentPoint = Random.Range(0, 8);
            
            
            agent.SetDestination(controlPoints[currentPoint].position);

        }


        }
        else
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }


    }

    
}
