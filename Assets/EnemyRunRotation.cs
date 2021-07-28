using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunRotation : MonoBehaviour
{
    [SerializeField] public float _rotationSpeed = 10f;
   

    // Update is called once per frame
    void Update()
    {
        RotationProcess();
    }
    private void RotationProcess()
    {
        if (Input.GetKey(KeyCode.H))
            RotateRight(_rotationSpeed);
        if (Input.GetKey(KeyCode.K))
            RotateLeft(_rotationSpeed);
    }
    public void RotateRight(float rotationSpeed)
    {
         transform.Rotate(Time.deltaTime * rotationSpeed * Vector3.down);
        // Quaternion aa =   transform.rotation ; 
    }
    public void RotateLeft(float rotationSpeed)
    {
        transform.Rotate(Time.deltaTime * rotationSpeed * Vector3.up);
    }
}
