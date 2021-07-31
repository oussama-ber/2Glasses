using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 10f;
    [SerializeField] public float sprintMovement = 15f;
    [SerializeField] public float backSpeed = 5f;
    [SerializeField] public float rotationSpeed = 3f;

    public GunRotation gunRotation;
    public Light bodyLight;
    public Light topLight;
    Rigidbody rb;
    public Vector3 quaternionToVector;
    public Quaternion startQuaternion;
    Quaternion current;
    Quaternion toGo;
    public float floatToAdd = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        quaternionToVector = startQuaternion.eulerAngles;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovementProcess();
        RotationProcess();
    }
    void MovementProcess()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            // transform.position += Time.deltaTime * movementSpeed * transform.forward;
            rb.velocity = transform.forward * movementSpeed;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            bodyLight.enabled = true;
            topLight.enabled = true;
            // transform.position += Time.deltaTime * backSpeed * -transform.forward;
            rb.velocity = -transform.forward * movementSpeed;
        }
        // else if (Input.GetKey(KeyCode.W))
        // {
        //     transform.position += Time.deltaTime * sprintMovement * transform.forward;
        // }
        else
        {   rb.velocity = new Vector3(0,0,0);
            bodyLight.enabled = false;
            topLight.enabled = false;
        }
    }
    void RotationProcess()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion currentRotation = transform.rotation;
            floatToAdd += 1f;
            Quaternion wantedRotation = Quaternion.Euler(0, floatToAdd, 0);
            
            transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed); 
            //we dont need to move the gun of the tank to the other angle.
            // gunRotation.RotateRight(rotationSpeed, floatToAdd);

           
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            Quaternion currentRotation = transform.rotation;
            floatToAdd -= 1f;
            Quaternion wantedRotation = Quaternion.Euler(0, floatToAdd, 0);
            transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed); 
            // transform.Rotate(Time.deltaTime * rotationSpeed * Vector3.down);
            //  we dont need to move the gun of the tank to the other angle.
            // gunRotation.RotateLeft(rotationSpeed, floatToAdd);
        }
        else 
        {
            //  transform.rotation = ;
        }
    }
}
