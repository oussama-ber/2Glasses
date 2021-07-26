using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveUsingRaycast : MonoBehaviour
{
    MoveAlong moveAlongScript;

    [SerializeField] float range = 300f;
    [SerializeField] float speed = 5f;
   // [SerializeField] float SpeedAlong = 3.5f;

    Vector3 zeroVector = new Vector3(0, 0, 0);

    Vector3 playerPosition = new Vector3(0, 0, 0);
    public GameObject playerLight;  
    public GameObject player;
 
  


    void Start()
    {

        moveAlongScript = GetComponent<MoveAlong>();
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

        bool forwardBool = Physics.Raycast(rayForward, out hitForward, range);
        bool backBool = Physics.Raycast(rayBack, out hitBack, range);
        bool rightBool = Physics.Raycast(rayRight, out hitRight, range);
        bool leftBool = Physics.Raycast(rayLeft, out hitLeft, range);



        // the last position of player
        //Begin Player detection---------------------------------------------------------------------------------------------
        //check if the ray detect something update the position of the player (target postion)
        if (forwardBool)
        {
            if (hitForward.transform.name == "BluePlayer")
            {
                // Debug.Log("moving forward");
                playerPosition = hitForward.transform.position;
                
            }
        }
        if (backBool)
        {
            if (hitBack.transform.name == "BluePlayer")
            {
                // Debug.Log("back");
                playerPosition = hitBack.transform.position;

            }
        }
        if (rightBool)
        {
            if (hitRight.transform.name == "BluePlayer")
            {
                // Debug.Log("hitRight");
                playerPosition = hitRight.transform.position;

            }
        }
        if (leftBool)
        {
            if (hitLeft.transform.name == "BluePlayer")
            {
                // Debug.Log("hitLeft");
                playerPosition = hitLeft.transform.position;
            }
        }
    
        //End Player detection---------------------------------------------------------------------------------------------
        
        if (transform.position == playerPosition)
        {
            playerPosition = zeroVector;
            moveAlongScript.enabled = true;

            // rechange the player's color if not any more detected. (the fake zombie detect him and reach his stored place)
            if(playerLight != null)
            playerLight.GetComponent<Light>().color = Color.white; 
        }
        if ((playerPosition != zeroVector))
        {
            moveAlongScript.enabled = false;
            //change player's color if detected
            if(playerLight != null)
            playerLight.GetComponent<Light>().color = Color.red; 

            
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);
        }
        else
        {
            // Debug.Log("make the moveAlongScript enable ");
            moveAlongScript.enabled = true;

        }


    }
    




}
