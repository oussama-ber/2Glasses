using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyReloading : MonoBehaviour
{
    public GameObject reloadStation;
    public float speed = 20f;
    public ParticleSystem reloadingParticules;
       NavMeshAgent agent;
       Vector3 target;
    void Start()
    {
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyShooting>().enabled = false;
        agent = GetComponent<NavMeshAgent>();
        
        // Reloading();
    }
    void Update()
    {
        Reloading();
    }
    void Reloading()
    {
        if(target != null)
        {

        target = reloadStation.transform.position;
        agent.SetDestination(target);
        }
        // transform.position = Vector3.MoveTowards(transform.position, reloadStation.transform.position, speed * Time.deltaTime);
    }
     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ReloadStation")
        {
            Destroy(reloadStation);
            transform.Rotate(0,90f,0);
            reloadingParticules.Play();
            Debug.Log("reloding seccess !!! we should increase the ammo");
           agent.Stop();
            GetComponent<EnemyMovement>().enabled = true;
            GetComponent<EnemyShooting>().enabled = true;
             GetComponent<EnemyMoveAlong>().enabled=true;
            GetComponent<EnemyReloading>().enabled = false;
        }
    }
}
