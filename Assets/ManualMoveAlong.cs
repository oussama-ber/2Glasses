using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMoveAlong : MonoBehaviour
{
    public float emenyRange = 200f;
    public float movementSpeed = 5f;
    public float floatToAdd = 0;
    public float rotationSpeed = 6f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     RotationProcess();
    // }
    void FixedUpdate()
    {
        RotationProcess();
        Move();
    }
    void Move()
    {
        // transform.position += movementSpeed * Time.deltaTime * transform.forward;

        rb.velocity = transform.forward * movementSpeed;
        // Debug.Log("moving");
        // transform.position = Vector3.Lerp(transform.position, Vector3.forward, movementSpeed);


    }
    void RotationProcess()
    {
        Vector3 raycastOffset = Vector3.zero;
        //set direction.
        Vector3 directionForward = transform.forward;
        //set origins.
        Vector3 origin = transform.position;
        Vector3 rightOrigin = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);
        Vector3 leftOrigin = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
        //drawRays
        Debug.DrawRay(origin, directionForward * 200f, Color.red);
        Debug.DrawRay(rightOrigin, directionForward * 200f, Color.cyan);
        Debug.DrawRay(leftOrigin, directionForward * 200f, Color.cyan);
        //Rays
        Ray rayForward = new Ray(origin, directionForward);
        Ray rayRightForward = new Ray(rightOrigin, directionForward);
        Ray rayLeftForward = new Ray(leftOrigin, directionForward);
        //hit forwards
        RaycastHit hitForward;
        RaycastHit hitRightForward;
        RaycastHit hitLeftForward;
        // booliens for hitforwards
        bool forwardBool = Physics.Raycast(rayForward, out hitForward, emenyRange);
        bool rightForwardBool = Physics.Raycast(rayRightForward, out hitRightForward, emenyRange);
        bool leftForwardBool = Physics.Raycast(rayLeftForward, out hitLeftForward, emenyRange);
        if (forwardBool)
        {
            if ((hitForward.transform.gameObject.tag == "obstacles") || (hitForward.transform.gameObject.tag == "ReloadStation"))
            {
                if (hitForward.distance <= 5f)
                {
                   CriticalRotation();
                }
            }
        }

        if (rightForwardBool)
        {
            if ((hitRightForward.transform.gameObject.tag == "obstacles") || (hitRightForward.transform.gameObject.tag == "ReloadStation"))
            {
                if (hitRightForward.distance <= 50f)
                {
                    raycastOffset -= Vector3.right;
                    floatToAdd -= 1f;
                    if (hitRightForward.distance <= 30f)
                    {
                        floatToAdd -= 3f;
                    }
                }

            }
            else
            if (leftForwardBool)
            {
                if ((hitLeftForward.transform.gameObject.tag == "obstacles") || (hitLeftForward.transform.gameObject.tag == "ReloadStation"))
                {
                    if (hitLeftForward.distance <= 50f)
                    {
                        raycastOffset += Vector3.right;
                        floatToAdd += 1f;
                        if (hitLeftForward.distance <= 30f)
                        {
                            floatToAdd += 3f;
                        }
                    }

                }
            }
            if (raycastOffset != Vector3.zero)
            {
                // Debug.Log("rotating");
                // transform.rotation =
                // transform.Rotate(raycastOffset * Time.deltaTime * 5f);
                // floatToAdd += 1f;
                Rotate(floatToAdd);
            }

        }
    }
    void Rotate(float floatToAdd)
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion wantedRotation = Quaternion.Euler(0, floatToAdd, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
    }
    void CriticalRotation()
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion wantedRotation = Quaternion.Euler(0, 180, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
    }
}
