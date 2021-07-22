using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyController : MonoBehaviour
{
    Transform target; 
    NavMeshAgent agent;
    void Start()
    {
        target = PlayerManager.instance.player.transform; 
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
