using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// Wes
// Source from the textbook in the Basic AI and Enemy Behavior chapter========
public class EnemyBehavior : MonoBehaviour
{
    public Transform route;
    public Transform player;


    private NavMeshAgent agent;
    void Start()
    {
        // Set the current agent to the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        // Find the player
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // Update the agents destination to the players current position. 
        agent.destination = player.position;
        
    }
}
