using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformPositionWithInputSmoothlyAndRotation : MonoBehaviour
{
    [SerializeField] float speed = 2f; 
    [SerializeField] float rotationSpeed = 20f; 
    

    void Update()
    {
       ResetPosition();
       MoveProcess();
       RotateProcess();
    }
    void ResetPosition()
    {
        if (Input.GetKey(KeyCode.Space))
            transform.position = new Vector3(0, 0.75f, 0); 
    }
    void MoveProcess()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += Time.deltaTime* speed * transform.right; 
        if (Input.GetKey(KeyCode.Q))
            transform.position += Time.deltaTime* speed * -transform.right; 
        if (Input.GetKey(KeyCode.Z))
            transform.position +=Time.deltaTime* speed * transform.forward; 
        if (Input.GetKey(KeyCode.S))
            transform.position += Time.deltaTime* speed * -transform.forward; 
    }
    void RotateProcess()
    {
        if(Input.GetKey(KeyCode.A))
            transform.Rotate(Time.deltaTime *  rotationSpeed * Vector3.down);
        if(Input.GetKey(KeyCode.E))
            transform.Rotate(Time.deltaTime *  rotationSpeed * Vector3.up);
    }

}
