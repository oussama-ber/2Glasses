using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Movement : MonoBehaviour
{
    Rigidbody rb; 
    [SerializeField] float moveSpeed = 10f; 
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float movementForce = 10f;
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
         CheckMainMenu();
       
        
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
            transform.position += Time.deltaTime* speed *  transform.right; 
        if (Input.GetKey(KeyCode.Q))
           transform.position += Time.deltaTime* speed * -transform.right; 
        if (Input.GetKey(KeyCode.Z))
            transform.position +=Time.deltaTime* speed * transform.forward; 
        if (Input.GetKey(KeyCode.S))
            transform.position += Time.deltaTime* speed * -transform.forward; 
    }
    void MoveWithForce()
    {
         if (Input.GetKey(KeyCode.D))
            rb.AddForce(movementForce * -transform.forward);
        if (Input.GetKey(KeyCode.Q))
            rb.AddForce(movementForce * transform.forward);; 
        if (Input.GetKey(KeyCode.Z))
            rb.AddForce(movementForce * transform.right);
        if (Input.GetKey(KeyCode.S))
           rb.AddForce(movementForce * -transform.right); 
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
            gameOver.enabled= true;
        }
    }
}
