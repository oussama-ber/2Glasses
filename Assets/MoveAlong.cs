using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
[SerializeField] float movementSpeed = 5f;
public Rigidbody rb ;
public bool noCollision = false; 

    private void Start() 
    {
        rb= GetComponent<Rigidbody>();
    
    }
    void FixedUpdate()
    {
            Move();
      
        //  rb.AddForce(transform.forward * movementSpeed);
    }
    
    void Move(){
        // rb.AddForce(transform.right * movementSpeed );
        transform.position += movementSpeed * Time.deltaTime * transform.forward;
    }
     void OnCollisionEnter(Collision other) 
     {       
         Debug.Log("collision");
         noCollision = false;  
        if (other.gameObject.tag == "RightWall")
        {
            
            Debug.Log(" Collision turn left");
          rb.AddForce(-transform.right * movementSpeed * 2);
        }
        if (other.gameObject.tag == "LeftWall")
        {
            Debug.Log("Collision trun right");
            rb.AddForce(transform.right * movementSpeed* 2 );
        }
        if (other.gameObject.tag == "TopWall")
        {
            Debug.Log("Collision turn back!!!!!!!!!!!!!");
            // transform.position += Time.deltaTime * movementSpeed * -transform.forward;
            GetComponent<MeshRenderer>().material.color = Color.red;
            rb.AddForce(-transform.forward * movementSpeed*2);
        }
        if (other.gameObject.tag == "BottomWall")
        {
            Debug.Log("Collision trun forward");
            rb.AddForce(-transform.forward * movementSpeed*2);
        }
            
        
    }
    
}
