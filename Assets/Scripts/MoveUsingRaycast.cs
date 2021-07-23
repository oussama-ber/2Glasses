using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveUsingRaycast : MonoBehaviour
{
MoveAlong moveAlongScript ; 

[SerializeField] float range = 300f ;
[SerializeField] float speed = 5f; 
[SerializeField] float SpeedAlong = 3.5f;

Vector3 zeroVector = new Vector3 (0, 0, 0); 

Vector3 playerPosition = new Vector3(0,0,0);
public Collider collider; 
public bool ShouldMove =  false;
        bool notForward =false;
        bool notBackk =false;
        bool notRight =false;
        bool notLeft =false;
        bool boolForward =false;
        bool boolBack =false;
        bool boolRight =false;
        bool boolLeft =false;

    void Start() 
    {
        
         moveAlongScript = GetComponent<MoveAlong>() ;
        //  moveAlongScript.enabled = false ; 
        // notBack =true;
    }
     void FixedUpdate()
    {
       
            MoveToPlayer();

            

    }    private void MoveToPlayer()
    {

       TestRaycast();
       

    }
  
    private void TestRaycast()
    {
      
        Vector3 directionForward = transform.forward;
        Vector3 directionBack = - transform.forward;
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
        RaycastHit hitForward;
        RaycastHit hitBack;
        RaycastHit hitRight;
        RaycastHit hitLeft;

        bool forwardBool =  Physics.Raycast(rayForward, out  hitForward, range);
        bool backBool = Physics.Raycast(rayBack, out  hitBack, range);
        bool rightBool = Physics.Raycast(rayRight, out  hitRight, range);
        bool leftBool = Physics.Raycast(rayLeft, out  hitLeft, range);

       
        
        // the last position of player
        //Begin Player detection---------------------------------------------------------------------------------------------
        //check if the ray detect something update the position of the player (target postion)
        
        if(forwardBool)
        {
            boolForward = true;
            if(hitForward.transform.name == "BluePlayer")
            {
                Debug.Log("moving forward");
                playerPosition = hitForward.transform.position;
                notForward =false; 
            }
            else {
                notForward =true;
                Debug.Log("notForward = " + notForward);
            }
        }
        if(backBool)
        {
            boolBack = true;
            if (hitBack.transform.name == "BluePlayer") 
            {
                Debug.Log("back");
                // transform.position += Time.deltaTime * speed * directionBack ; 
                 playerPosition = hitBack.transform.position; 
                 notBackk = false;
            }else
            {
                notBackk = true;
                Debug.Log("notBack = " + notBackk);
            }
        }
        if(rightBool)
        {
            boolRight = true; 
            if (hitRight.transform.name == "BluePlayer") 
            {
                Debug.Log("hitRight");
                // transform.position += Time.deltaTime * speed * directionRight ;
                playerPosition = hitRight.transform.position; 
                notRight= false; 
            }else 
            {
                notRight= true;
                Debug.Log("notRight = " + notRight);
            }
        }
        if(leftBool)
        {
            boolLeft = true;
            if (hitLeft.transform.name == "BluePlayer") 
            {
                Debug.Log("hitLeft");
                // transform.position += Time.deltaTime * speed * directionLeft; 
                 playerPosition = hitLeft.transform.position; 
                    notLeft = false;
            }else{
                    notLeft = true;
                    Debug.Log("notLeft = " + notLeft);
                 }
        }
        
        // if (boolBack&&  boolForward&&  boolLeft&& boolRight)
        // {
        //     if(!(hitForward.transform.name == "BluePlayer") && !(hitBack.transform.name == "BluePlayer") && !(hitRight.transform.name == "BluePlayer") && !(hitLeft.transform.name == "BluePlayer"))
        //         transform.position += Time.deltaTime * SpeedAlong * transform.forward;
        // }
        //End Player detection---------------------------------------------------------------------------------------------
        if (transform.position == playerPosition)
        {
            playerPosition = zeroVector;
        }
        if ((playerPosition != zeroVector) )
        {
            moveAlongScript.enabled = false;  
            transform.position = Vector3.MoveTowards(transform.position, playerPosition , Time.deltaTime * speed);
        }else {
            Debug.Log("make the moveAlongScript enable ");
            moveAlongScript.enabled= true;
        }
        
        // else
        // if (((transform.position == playerPosition) || notForward && notBackk && notRight && notLeft))
        // {
            
        //     Debug.Log("...........................the cube must move forward");
        //     transform.position += Time.deltaTime * SpeedAlong * transform.forward;
        // }
        //check if the playpositon is not zero => go to target  
        //Begin Check wall detectio*******************************************
       
        //End Check wall detection********************************************        

    }
    // private void MoveAlong( RaycastHit hitForward,  RaycastHit hitBack,  RaycastHit hitRight,  RaycastHit hitLeft)
    // {
    //     // string name1 = hitForward.transform.tag; 
    //     // string name2 = hitBack.transform.name; 
    //     // string name3 = hitRight.transform.name; 
    //     // string name4 = hitLeft.transform.name; 

    //     RaycastHit _hitForward = hitForward;
    //     RaycastHit _hitBack =hitBack ;
    //     RaycastHit _hitRight = hitRight;
    //     RaycastHit _hitLeft = hitLeft;

    //     float forwardDis = hitForward.distance ; 
    //     float backDis = hitBack.distance;
    //     float rightDis = hitRight.distance;
    //     float leftDis = hitLeft.distance;

    //     float[] distances ={forwardDis, backDis , rightDis, leftDis};

    //     RaycastHit[] raycastHits = {_hitForward, _hitBack, _hitRight, _hitLeft };


        
    //      RaycastHit directionToGo = _hitForward ; 
    //       directionToGo.distance = 0f ; 
          

    //     for (int i = 0; i < raycastHits.Length; i++)
    //     {
            
    //     if (directionToGo.distance < raycastHits[i].distance)
    //         directionToGo = raycastHits[i];     
    //     }
    //     Debug.Log("check distance: the forwardDis" + _hitForward.distance + " backDis :"+ _hitBack.distance + " rightDis "+_hitRight.distance+ " leftDis "+_hitLeft.distance);
    //     Debug.Log(" the longest path is : " + directionToGo.distance);

    // //    if (( name1 != "BluePlayer") && ( name2 != "BluePlayer") && ( name3 != "BluePlayer")&& ( name4 != "BluePlayer"))
    // //     {

    // //         transform.position += Time.deltaTime * speed * directionForward ; 
            
    // //     }
        
    // }

   
     
}
