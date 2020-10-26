using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    
    NavMeshAgent agent;
    GameObject target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Capsule");
    }

    private void Update()
    {   
        // this will set the enemy destination as player position to move towards payer.
        agent.SetDestination(target.transform.position);
    }


}
