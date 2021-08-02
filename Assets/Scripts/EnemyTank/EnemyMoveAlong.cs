using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAlong : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed = 5f;
    public float[] randomAngles = { 90, -90, 180 };
    public bool isNotColliding = true;
    public EnemyTankEasy enemyLevel;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        isNotColliding = true;
        movementSpeed = enemyLevel.speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Move();
    }

    void Move()
    {
        if (isNotColliding)
        {
             rb.velocity = (movementSpeed * transform.forward);
            //  transform.position += movementSpeed * Time.deltaTime * transform.forward;
        }
        else 
        {
            rb.velocity = new Vector3 (0,0,0);
        }
    }
    
    // private void OnCollisionEnter(Collision coll)
    // {
    //     if (coll.gameObject.tag != "Ground")
    //     {
    //     Debug.Log("we collide with" + coll.gameObject.name);
    //     isNotColliding = false;
    //     Debug.Log("change angle");
    //     transform.Rotate(0, RandomAngle(), 0);
    //     isNotColliding=true;

    //     }
    // }
    private float RandomAngle()
    {
        int randomIndex = Random.Range(1, 3);
        return randomAngles[randomIndex];
    }

}
