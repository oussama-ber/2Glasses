using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadStationSpawner : MonoBehaviour
{
  
   public GameObject reloadStationPrefab;
   public GameObject[] spawners;
   public int score = 0 ; 
    void Start() 
    {
        spawners = new GameObject[4];
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject; 
        }
    
        // float currentHealthTest = reloadStationPrefab;.GetComponent<ZombieHealth>().currentHealth;
    //    StationSpawner();
       Debug.Log("current Score " + Score.currentScore);
    }
   
 

    
    public void StationSpawner()
    {
        int randomPoint = Random.Range(0, spawners.Length);                                                                                 
        // Instantiate(reloadStationPrefab, spawners[randomPoint].transform.position, spawners[randomPoint].transform.rotation);
        // Debug.Log("the reloadStation tag is : " + reloadStationPrefab.tag);
        reloadStationPrefab.transform.position = spawners[randomPoint].transform.position;
        //float currentHealthTest = reloadStationPrefab.GetComponent<ZombieHealth>().currentHealth;
        //Debug.Log("ZombieSpawn Method : " + currentHealthTest); 
        
    }
   

    public bool ShouldSpawn()
    {
        // if ()
        return true;

    }
}
