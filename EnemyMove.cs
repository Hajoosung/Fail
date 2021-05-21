using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public List<Transform> locations;
    public Transform patrolRoute;

    private int locationIndex = 0;
    private NavMeshAgent agent;
    private GameBehavior gameManager;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        InitializePatrolRoute();
        MoveToNextPatrolPoint();

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolPoint();
        }

    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolPoint()
    {
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }

}