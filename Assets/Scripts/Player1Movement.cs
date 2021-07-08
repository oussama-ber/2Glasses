using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    Rigidbody rb; 
    [SerializeField] float moveSpeed = 10f; 
    public string zAxis = "Vertical";
    public string xAxis = "Horizontal";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         translateMover();
       
        
    }
    void translateMover()
    {
        float xValue = Input.GetAxis(xAxis) * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis(zAxis) * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }
}
