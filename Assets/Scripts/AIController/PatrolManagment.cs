using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolManagment : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints;
    [SerializeField] private float speed;

    private int currentPointIndex = 0;

    public NavMeshAgent agent;

    private void Awake()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        if (patrolPoints == null || patrolPoints.Count == 0)
        {
            Debug.LogError("No patrol points assigned to the PatrolManagment script.");
        }
    }

    private void Start()
    {
        if (patrolPoints != null && patrolPoints.Count > 0)
        {
            agent.SetDestination(patrolPoints[0].position);
        }
    }

    private void Update()
    {
        Patrol();
    }

    private void OnEnable()
    {
        PanelMouse.OnBuildingClick += ChangeDestination;
    }

    private void OnDisable()
    {
        PanelMouse.OnBuildingClick -= ChangeDestination;
    }

    private void ChangeDestination(Vector3 transform)
    {
        if (agent != null)
            agent.SetDestination(transform);
    }

    void Patrol()
    {
        if (patrolPoints == null || patrolPoints.Count == 0)
            return;

        Transform targetPoint = patrolPoints[currentPointIndex];

        // Si el agente ha llegado al destino (o está muy cerca), pasar al siguiente punto
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Count;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }
}
