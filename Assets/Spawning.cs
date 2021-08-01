using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
     public GameObject position1;
     public GameObject position2;
     public GameObject position3;
     public GameObject position4;
     public GameObject[] spawners= new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        spawners[0] = position1;
        spawners[1] = position2;
        spawners[2] = position3;
        spawners[3] = position4;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    
    public void ChangePosition()
    {
        int randomPointIndex = Random.Range(0,spawners.Length);
        gameObject.transform.position = spawners[randomPointIndex].transform.position;
        gameObject.transform.rotation = spawners[randomPointIndex].transform.rotation;
    }
}
