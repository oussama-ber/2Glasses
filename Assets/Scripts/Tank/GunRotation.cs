using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float _rotationSpeed = 3f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationProcess();

    }

    private void RotationProcess()
    {
        if (Input.GetKey(KeyCode.A))
            RotateRight(_rotationSpeed);
        if (Input.GetKey(KeyCode.E))
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
