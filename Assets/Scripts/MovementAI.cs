using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementAI : MonoBehaviour
{
    NavMeshAgent nMA ; 
    public Transform target;

    void Awake() 
    {
       nMA = GetComponent<NavMeshAgent>();
       nMA.SetDestination(target.position);
       Debug.Log("Target position : " + target.position);

    }

    void Update()
    {
        nMA.SetDestination(target.position);
        Debug.Log("From update position: "+target.position);
    }
}
