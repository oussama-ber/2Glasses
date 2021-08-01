using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(LineRenderer))]
public class GunRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float _rotationSpeed = 3f;
    [SerializeField] public float _turnSpeed = 0.9f;

    // public int reflections;
    // public float maxLength;

    // private LineRenderer lineRenderer;
    // private Ray ray;
    // private RaycastHit hit;
    // private Vector3 direction;
    
     void Awake() {
        // lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotationProcess();
        // DisplayAimRay();

    }

    private void RotationProcess()
    {
        // if (Input.GetKey(KeyCode.A))
        //     RotateRight(_rotationSpeed);
        // if (Input.GetKey(KeyCode.E))
        //     RotateLeft(_rotationSpeed);
        float horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(horizontal * _turnSpeed * Vector3.up, Space.World);
    }
    public void RotateRight(float rotationSpeed, float floatToAdd)
    {
        Quaternion currentRotation = transform.rotation;
        floatToAdd += 1f;
        Quaternion wantedRotation = Quaternion.Euler(0, floatToAdd, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        // transform.Rotate(Time.deltaTime * rotationSpeed * Vector3.down);
        // Quaternion aa =   transform.rotation ; 
    }
    public void RotateLeft(float rotationSpeed, float floatToAdd)
    {
        Quaternion currentRotation = transform.rotation;
        floatToAdd -= 1f;
        Quaternion wantedRotation = Quaternion.Euler(0, floatToAdd, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        // transform.Rotate(Time.deltaTime * rotationSpeed * Vector3.up);
    }
    // public void DisplayAimRay()
    // {
    //     ray = new Ray (transform.position, transform.forward);
    //     lineRenderer.positionCount = 1;
    //     lineRenderer.SetPosition(0, ray.origin +ray.direction * maxLength);
    // }
}
