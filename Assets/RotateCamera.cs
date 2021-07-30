using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 6f;
    public GameObject rotationPoint;
    public Vector3  rotationPosition; 

private void Start() {
      rotationPosition = rotationPoint.transform.position;
}
    void FixedUpdate()
    {
        
        transform.RotateAround(rotationPosition,  Vector3.up, 20 * Time.deltaTime);
    }
}
