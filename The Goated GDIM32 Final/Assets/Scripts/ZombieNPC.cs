using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNPC : MonoBehaviour
{
    public Transform player;

    private UnityEngine.AI.NavMeshAgent agent;

    public float chaseDistance = 10f;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

   
    void Update()
    {
        agent.SetDestination(player.position);
        
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < chaseDistance)
        {
            agent.SetDestination(player.position);
        }
    }

}
