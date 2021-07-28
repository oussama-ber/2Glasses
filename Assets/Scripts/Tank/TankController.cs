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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementProcess();
        RotationProcess();
    }
    void MovementProcess()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += Time.deltaTime * movementSpeed * transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            bodyLight.enabled = true;
            topLight.enabled = true;
            transform.position += Time.deltaTime * backSpeed * -transform.forward;
        }else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Time.deltaTime * sprintMovement * transform.forward;
        }
        else
        {
            bodyLight.enabled = false;
            topLight.enabled = false;
        }
    }
    void RotationProcess()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Time.deltaTime * rotationSpeed * Vector3.up);
            //Rotate the toptank the other way the Tank body.
            gunRotation.RotateRight(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Time.deltaTime * rotationSpeed * Vector3.down);
            //Rotate the toptank the other way the Tank body.
            gunRotation.RotateLeft(rotationSpeed);
        }
    }
}
