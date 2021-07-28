using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyMoveAlong moveAlongScript;

    [SerializeField] float emenyRange = 300f;
    // [SerializeField] float rotationSpeed = 100f;

    [SerializeField] float speed = 5f;
    // [SerializeField] float SpeedAlong = 3.5f;

    Vector3 zeroVector = new Vector3(0, 0, 0);

    Vector3 playerPosition = new Vector3(0, 0, 0);
    public GameObject playerLight;
    public GameObject player;




    void Start()
    {

        moveAlongScript = GetComponent<EnemyMoveAlong>();
    }
    void FixedUpdate()
    {
        MoveToPlayer();
    }
    private void MoveToPlayer()
    {
        TestRaycast();
    }

    private void TestRaycast()
    {
        Vector3 directionForward = transform.forward;
        Vector3 directionBack = -transform.forward;
        Vector3 directionRight = transform.right;
        Vector3 directionLeft = -transform.right;
        Vector3 origin = transform.position;
        Debug.DrawRay(origin, directionForward * 200f, Color.red);
        Debug.DrawRay(origin, directionBack * 200f, Color.red);
        Debug.DrawRay(origin, directionRight * 200f, Color.red);
        Debug.DrawRay(origin, directionLeft * 200f, Color.red);
        Ray rayForward = new Ray(origin, directionForward);
        Ray rayBack = new Ray(origin, directionBack);
        Ray rayRight = new Ray(origin, directionRight);
        Ray rayLeft = new Ray(origin, directionLeft);
        RaycastHit hitForward;
        RaycastHit hitBack;
        RaycastHit hitRight;
        RaycastHit hitLeft;

        bool forwardBool = Physics.Raycast(rayForward, out hitForward, emenyRange);
        bool backBool = Physics.Raycast(rayBack, out hitBack, emenyRange);
        bool rightBool = Physics.Raycast(rayRight, out hitRight, emenyRange);
        bool leftBool = Physics.Raycast(rayLeft, out hitLeft, emenyRange);



        // the last position of player
        //Begin Player detection---------------------------------------------------------------------------------------------
        //check if the ray detect something update the position of the player (target postion)
        if (forwardBool)
        {
            if (hitForward.transform.name == "Tank")
            {
                // Debug.Log("moving forward");
                playerPosition = hitForward.transform.position;

            }
        }
        if (backBool)
        {
            if (hitBack.transform.name == "Tank")
            {
                // Debug.Log("back");
                playerPosition = hitBack.transform.position;
                transform.Rotate(0, 180f, 0);

            }
        }
        if (rightBool)
        {
            if (hitRight.transform.name == "Tank")
            {
                // Debug.Log("hitRight");
                playerPosition = hitRight.transform.position;
                transform.Rotate(0, 90f, 0);

            }
        }
        if (leftBool)
        {
            if (hitLeft.transform.name == "Tank")
            {
                // Debug.Log("hitLeft");
                playerPosition = hitLeft.transform.position;
                transform.Rotate(0, -90f, 0);
            }
        }

        //End Player detection---------------------------------------------------------------------------------------------

        if (transform.position == playerPosition)
        {
            playerPosition = zeroVector;
            moveAlongScript.enabled = true;

            // rechange the player's color if not any more detected. (the fake zombie detect him and reach his stored place)
            if (playerLight != null)
                playerLight.GetComponent<Light>().color = Color.white;
        }
        if ((playerPosition != zeroVector))
        {
            moveAlongScript.enabled = false;
            //change player's color if detected
            if (playerLight != null)
                playerLight.GetComponent<Light>().color = Color.red;


            transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);
        }
        else
        {
            Debug.Log("make the moveAlongScript enable ");
            moveAlongScript.enabled = true;

        }


    }
}
