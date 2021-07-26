using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Movement : MonoBehaviour
{
    Rigidbody rb;
    // [SerializeField] float moveSpeed = 10f;
    // [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] public float speed = 20f;
    [SerializeField] public float sprintSpeed = 20f;
    [SerializeField] private float movementSide = 10f;
    [SerializeField] public float walkSpeed = 17f;
    public GameOver gameOver;
    public string zAxis = "Vertical";
    public string xAxis = "Horizontal";
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //   translateMover(); //kjdsfg jldsfgsdfljkg ldskfhg 
        MoveProcess();
        //  RotateProcess();
        // CheckMainMenu();


    }
    // void translateMover()
    // {
    //     float xValue = Input.GetAxis(xAxis) * Time.deltaTime * moveSpeed;
    //     float zValue = Input.GetAxis(zAxis) * Time.deltaTime * moveSpeed;
    //     transform.Translate(xValue, 0, zValue);
    // }
    void MoveProcess()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += Time.deltaTime * movementSide * transform.right;
        if (Input.GetKey(KeyCode.Q))
            transform.position += Time.deltaTime * movementSide * -transform.right;
        if (Input.GetKey(KeyCode.Z))
            transform.position += Time.deltaTime * walkSpeed * transform.forward;
        if (Input.GetKey(KeyCode.S))
            transform.position += Time.deltaTime * walkSpeed * -transform.forward;
        //Run
        if (Input.GetKey(KeyCode.W))
            transform.position += Time.deltaTime * sprintSpeed * -transform.right;
    }
    void MoveWithForce()
    {
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(sprintSpeed * -transform.forward);
        if (Input.GetKey(KeyCode.Q))
            rb.AddForce(sprintSpeed * transform.forward); ;
        if (Input.GetKey(KeyCode.Z))
            rb.AddForce(sprintSpeed * transform.right);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(sprintSpeed * -transform.right);
        // run
        if (Input.GetKey(KeyCode.W))
            transform.position += Time.deltaTime * walkSpeed * -transform.right;
        // rb.velocity  = new Vector3 ( transform.forward); 
    }
    //  void RotateProcess()
    // {
    //     if(Input.GetKey(KeyCode.A))
    //         transform.Rotate(Time.deltaTime *  rotationSpeed * Vector3.down);
    //     if(Input.GetKey(KeyCode.E))
    //         transform.Rotate(Time.deltaTime *  rotationSpeed * Vector3.up);
    // }
    void CheckMainMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
            gameOver.enabled = true;
        }
    }
}
