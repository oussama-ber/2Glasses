using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySphereCast : MonoBehaviour
{
     public float sphereRadius = 30f;
    public float maxDistance = 50f;
    public GameObject enemyGun;
    // public LayerMask layerMask;
    public float movementSpeed = 3.5f;
    // public GameObject playerLight;
    Transform target;


    private Vector3 origin;
    private Vector3 direction;
    private float curretnHitDistance;
    private Vector3 playerPosition;
    // test 
    public GameObject PlayerTank;
    public float rotationSpeed = 100f; 
    private float hitDistance;
    public Vector3  directionPlayer;
    public bool hitBool = false;



    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    void FixedUpdate()
    {
        MoveToPlayer();
    }
    void MoveToPlayer()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        hitBool = Physics.SphereCast(origin, sphereRadius * 3, direction, out hit);
        if (hitBool)
        { 
            if (hit.transform.gameObject.tag == "Tank")
            {
            directionPlayer= hit.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(directionPlayer);
            enemyGun.transform.rotation = Quaternion.Lerp(enemyGun.transform.rotation, rotation, rotationSpeed* Time.deltaTime);
       
            }
            if (playerPosition != Vector3.zero)
            {

            }

        }
        else
        {
            hitBool = false;
            playerPosition = Vector3.zero;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (hitBool)
        {

        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * curretnHitDistance);
        Gizmos.DrawWireSphere(transform.position+ direction* hitDistance , sphereRadius* 3);
        }

    }
    void Move(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
    }
  
}
