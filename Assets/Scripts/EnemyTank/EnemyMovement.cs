using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public ManualMoveAlong moveAlongScript;
    public GameObject playerLight;
    public GameObject enemyLight;
    [SerializeField] float emenyRange = 300f;
    // [SerializeField] float rotationSpeed = 100f;
    public float speed;
    public float speedTest = 30;
    // [SerializeField] float SpeedAlong = 3.5f;
    Vector3 zeroVector = new Vector3(0, 0, 0);
    Vector3 playerPosition = new Vector3(0, 0, 0);
    public EnemyTankEasy enemyLevel;
    public float floatToAdd;
    public float rotationSpeed = 10f;
    Vector3 directionPlayer;
    Quaternion rotation;
    // float playerDistance = new Vector3(0, 0, 0);


    Rigidbody rb;

    void Start()
    {
        enemyLight.GetComponent<Light>();
        rb = GetComponent<Rigidbody>();
        moveAlongScript = GetComponent<ManualMoveAlong>();
        speed = enemyLevel.speed;
    }
    void FixedUpdate()
    {
        MoveToPlayer();
    }
    private void MoveToPlayer()
    {
        DetectingTankWithRaycast();
    }
    private void DetectingTankWithRaycast()
    {
        Vector3 directionForward = transform.forward;
        Vector3 directionBack = -transform.forward;
        Vector3 directionRight = transform.right;
        Vector3 directionLeft = -transform.right;
        Vector3 origin = transform.position;
        Debug.DrawRay(origin, directionForward * 200f, Color.cyan);
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
        bool shouldStop = false;
// the last position of player
//Begin Player detection---------------------------------------------------------------------------------------------
//check if the ray detect something update the position of the player (target postion)
        if (forwardBool)
        {
            if (hitForward.transform.name == "Tank")
            {
                directionPlayer = hitForward.transform.position - transform.position;
                rotation = Quaternion.LookRotation(directionPlayer);
                playerPosition = hitForward.transform.position;
                if (hitForward.distance <= 15f)
                {
                    shouldStop = true;
                }
            }
        }
        if (backBool)
        {
            if (hitBack.transform.name == "Tank")
            {
                Debug.Log("back");
                directionPlayer = hitBack.transform.position - transform.position;
                rotation = Quaternion.LookRotation(directionPlayer);
                playerPosition = hitBack.transform.position;
                if (hitBack.distance <= 15f)
                {
                    shouldStop = true;
                }
            }
        }
        if (rightBool)
        {
            if (hitRight.transform.name == "Tank")
            {
                Debug.Log("hitRight");
                directionPlayer = hitRight.transform.position - transform.position;
                rotation = Quaternion.LookRotation(directionPlayer);
                playerPosition = hitRight.transform.position;
                if (hitRight.distance <= 15f)
                {
                    shouldStop = true;
                }
            }
        }
        if (leftBool)
        {
            if (hitLeft.transform.name == "Tank")
            {
                Debug.Log("hitLeft");
                directionPlayer = hitLeft.transform.position - transform.position;
                rotation = Quaternion.LookRotation(directionPlayer);
                playerPosition = hitLeft.transform.position;
                if (hitLeft.distance <= 15f)
                {
                    shouldStop = true;
                }
            }
        }
//End Player detection---------------------------------------------------------------------------------------------
        if (shouldStop)
        {
            // playerPosition = zeroVector;
            rb.velocity = Vector3.zero;
            playerPosition = Vector3.zero;
            GetComponent<ManualMoveAlong>().enabled = false;
            Debug.Log("should not moveeeee");
        }
        if (transform.position == playerPosition) // not working
        {
            Debug.Log("should Stop");
            playerPosition = zeroVector;

            if (!moveAlongScript.enabled)
                GetComponent<ManualMoveAlong>().enabled = true;
            // rechange the player's color if not any more detected. (the fake zombie detect him and reach his stored place)
            playerLight.GetComponent<Light>().color = Color.white;
            enemyLight.GetComponent<Light>().color = Color.white;
        }
        if (playerPosition == transform.position)
        {
            Debug.Log("bingooooooooooooooooooooooooooooooooooooooooooooooooo");
        }
        if ((playerPosition != zeroVector)) // works
        {
            // Debug.Log("doingSomething");

            if (moveAlongScript.enabled)
            {
                GetComponent<ManualMoveAlong>().enabled = false;
            }
            Rotate(rotation);
            // Moveforward();
            Invoke("Moveforward", 1f);
            //change player's color if detected
            playerLight.GetComponent<Light>().color = Color.red;
            enemyLight.GetComponent<Light>().color = Color.red;
        }
    }
    void Rotate(Quaternion rotation)
    {
        // Debug.Log("rotating from method");
        // transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation,  rotationSpeed);
    }
    void Moveforward()
    {
        // Debug.Log("moving from method");
        // rb.velocity = transform.forward * speedTest;
        transform.position = Vector3.Lerp(transform.position, playerPosition, Time.deltaTime * speedTest);
        
    }
}
