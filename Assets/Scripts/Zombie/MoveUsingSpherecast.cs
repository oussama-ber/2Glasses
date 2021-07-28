using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUsingSpherecast : MonoBehaviour
{
    public float sphereRadius = 20f;
    public float maxDistance = 30f;
    public GameObject currentObject;
    public LayerMask layerMask;
    public float movementSpeed = 3.5f;
    public GameObject playerLight;
    Transform target;


    private Vector3 origin;
    private Vector3 direction;
    private float curretnHitDistance;
    private Vector3 playerPosition;



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
        bool hitBool = Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance);
        if (hitBool)
        {
            currentObject = hit.transform.gameObject;


            if (hit.transform.gameObject.tag == "BluePlayer")
            {
                GetComponent<MoveAlong>().enabled = false;
                playerPosition = hit.transform.position;
            }

            if (playerPosition != Vector3.zero)
            {
                playerLight.GetComponent<Light>().color = Color.red;
                Move(playerPosition);
            }

        }
        else
        {
            currentObject = null;
            playerPosition = Vector3.zero;
            GetComponent<MoveAlong>().enabled = true;
            playerLight.GetComponent<Light>().color = Color.white;
            

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        // Debug.DrawLine(origin, origin + direction * curretnHitDistance);
        Gizmos.DrawWireSphere(origin, sphereRadius);

    }
    void Move(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
    }

}
