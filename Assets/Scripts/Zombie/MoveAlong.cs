using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 5f;
    public Rigidbody rb;
    public bool noCollision = true;
    public float[] randomAngles = { 90, -90, 180 };

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        // Debug.Log("noCollision = " + noCollision);
        Move();

        //  rb.AddForce(transform.forward * movementSpeed);
    }

    void Move()
    {
        // rb.AddForce(transform.right * movementSpeed );
        if (noCollision)
        {
            transform.position += movementSpeed * Time.deltaTime * transform.forward;
        }

    }
    void OnCollisionEnter(Collision other)
    {
        // Debug.Log("collision");
        noCollision = false;
        // Debug.Log("change angle ");
        transform.Rotate(0f, RandomAngleFloat(), 0);
        noCollision = true;

        // if (other.gameObject.tag == "RightWall")
        // {
        //     noCollision = false;
        //     Debug.Log(" Collision turn left");
        //     transform.Rotate(0f, 90f, 0);
        //     noCollision = true;

        // }
        // if (other.gameObject.tag == "LeftWall")
        // {
        //     noCollision = false;
        //     Debug.Log("Collision trun right");
        //     transform.Rotate(0f, RandomAngleFloat(), 0);
        //     noCollision = true;
        // }
        // if (other.gameObject.tag == "TopWall")
        // {
        //     noCollision = false;
        //     Debug.Log("Collision turn back!!!!!!!!!!!!!");

        //     GetComponent<MeshRenderer>().material.color = Color.red;
        //     transform.Rotate(0f, RandomAngleFloat(), 0);
        //     noCollision = true;


        // }
        // if (other.gameObject.tag == "BottomWall")
        // {
        //     noCollision = false;
        //     Debug.Log("Collision trun forward");
        //     transform.Rotate(0f, RandomAngleFloat(), 0);
        //     noCollision = true;
        // }
    }
    public float RandomAngleFloat()
    {
        int randomIndex = Random.Range(1, 3);

        return randomAngles[randomIndex];
    }
}
