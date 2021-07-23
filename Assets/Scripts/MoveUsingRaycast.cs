using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveUsingRaycast : MonoBehaviour
{

[SerializeField] float range = 300f ;
[SerializeField] float speed = 5f; 
        RaycastHit hitForward;
        RaycastHit hitBack;
        RaycastHit hitRight;
        RaycastHit hitLeft;
          string name1 ; 
        string name2 ; 
        string name3 ; 
        string name4 ; 

     void FixedUpdate()
    {
       
            MoveToPlayer();

    }
    private void MoveToPlayer()
    {
       TestRaycast();

    }
  
    private void TestRaycast()
    {
      
        Vector3 directionForward = transform.forward;
        Vector3 directionBack = -transform.forward;
        Vector3 directionRight = transform.right;
        Vector3 directionLeft = -transform.right;
        Vector3 origin = transform.position; 
        Debug.DrawRay(origin, directionForward * 200f , Color.red);
        Debug.DrawRay(origin, directionBack * 200f , Color.red);
        Debug.DrawRay(origin, directionRight * 200f , Color.red);
        Debug.DrawRay(origin, directionLeft * 200f , Color.red);
        Ray rayForward = new Ray(origin, directionForward);
        Ray rayBack = new Ray(origin, directionBack);
        Ray rayRight = new Ray(origin, directionRight);
        Ray rayLeft = new Ray(origin, directionLeft);
        Physics.Raycast(rayForward, out  hitForward, range);
        Physics.Raycast(rayBack, out  hitBack, range);
        Physics.Raycast(rayRight, out  hitRight, range);
        Physics.Raycast(rayLeft, out  hitLeft, range);
        if( Physics.Raycast(rayForward, out  hitForward, range))
        {
            if(hitForward.transform.name == "BluePlayer")
            {
                Debug.Log("forward");
                transform.position += Time.deltaTime * speed * directionForward ; 
            }
        } 
        //  else 
        // {
        // Debug.Log("blablaablablalablbalbal");
        // transform.position += Time.deltaTime * speed * directionForward ; 
        // }
        if(Physics.Raycast(rayBack, out  hitBack, range))
        {
            if (hitBack.transform.name == "BluePlayer") 
            {
                Debug.Log("back");
                transform.position += Time.deltaTime * speed * directionBack ; 
            }
        } 
        //  else 
        // {
        // Debug.Log("blablaablablalablbalbal");
        // transform.position += Time.deltaTime * speed * directionForward ; 
        // }
        if(Physics.Raycast(rayRight, out  hitRight, range))
        {
            if (hitRight.transform.name == "BluePlayer") 
            {
                Debug.Log("hitRight");
                transform.position += Time.deltaTime * speed * directionRight ; 
            }
        }  
        //  else 
        // {
        // Debug.Log("blablaablablalablbalbal");
        // transform.position += Time.deltaTime * speed * directionForward ; 
        // }
        if(Physics.Raycast(rayLeft, out  hitLeft, range))
        {
            if (hitLeft.transform.name == "BluePlayer") 
            {
                Debug.Log("hitLeft");
                transform.position += Time.deltaTime * speed * directionLeft; 
            }
        }
        // else 
        // {
        // Debug.Log("blablaablablalablbalbal");
        // transform.position += Time.deltaTime * speed * directionForward ; 
        // }

        // string name1 = hitForward.transform.tag; 
        // string name2 = hitBack.transform.tag; 
        // string name3 = hitRight.transform.tag; 
        // string name4 = hitLeft.transform.tag; 
         
        // if (!( name1 == "BluePlayer") && !( name2 == "BluePlayer") && !( name3 == "BluePlayer")&& !( name4 == "BluePlayer"))
        // {
        //     // MoveAlong(hitForward, hitBack, hitRight, hitLeft);
        //     transform.position += Time.deltaTime * speed * transform.right;
            
        // }

    }
    private void MoveAlong( RaycastHit hitForward,  RaycastHit hitBack,  RaycastHit hitRight,  RaycastHit hitLeft)
    {
        // string name1 = hitForward.transform.tag; 
        // string name2 = hitBack.transform.name; 
        // string name3 = hitRight.transform.name; 
        // string name4 = hitLeft.transform.name; 

        RaycastHit _hitForward = hitForward;
        RaycastHit _hitBack =hitBack ;
        RaycastHit _hitRight = hitRight;
        RaycastHit _hitLeft = hitLeft;

        float forwardDis = hitForward.distance ; 
        float backDis = hitBack.distance;
        float rightDis = hitRight.distance;
        float leftDis = hitLeft.distance;

        float[] distances ={forwardDis, backDis , rightDis, leftDis};

        RaycastHit[] raycastHits = {_hitForward, _hitBack, _hitRight, _hitLeft };


        
         RaycastHit directionToGo = _hitForward ; 
          directionToGo.distance = 0f ; 
          

        for (int i = 0; i < raycastHits.Length; i++)
        {
            
        if (directionToGo.distance < raycastHits[i].distance)
            directionToGo = raycastHits[i];     
        }
        Debug.Log("check distance: the forwardDis" + _hitForward.distance + " backDis :"+ _hitBack.distance + " rightDis "+_hitRight.distance+ " leftDis "+_hitLeft.distance);
        Debug.Log(" the longest path is : " + directionToGo.distance);

    //    if (( name1 != "BluePlayer") && ( name2 != "BluePlayer") && ( name3 != "BluePlayer")&& ( name4 != "BluePlayer"))
    //     {

    //         transform.position += Time.deltaTime * speed * directionForward ; 
            
    //     }
        
    }

   
     void OnCollisionEnter(Collision other) 
     {
        if (other.transform.tag == "RightWall")
            transform.position += Time.deltaTime * speed * transform.forward;
        if (other.transform.tag == "LeftWall")
            transform.position += Time.deltaTime * speed * -transform.forward;
        if (other.transform.tag == "TopWall")
            transform.position += Time.deltaTime * -speed * transform.right;
        if (other.transform.tag == "RightWall")
            transform.position += Time.deltaTime * speed * transform.right;
        
    }
}
