using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
   public Transform spawnerPoint;
   public GameObject ZombiePrefab;
   public GameObject[] spawners;
   public int score = 0 ; 
    void Start() 
    {
        spawners = new GameObject[4];
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject; 
        }
    
        float currentHealthTest = ZombiePrefab.GetComponent<ZombieHealth>().currentHealth;
       ZombieSpawn();
       Debug.Log("current Score " + Score.currentScore);
    }
   
 void Update() {
    float currentHealthTest = ZombiePrefab.GetComponent<ZombieHealth>().currentHealth;
    
    if ( Score.currentScore ==  (score + 1) )
    {
        Debug.Log("current Score " + Score.currentScore);
        Debug.Log("spawning a zombie!!!");
        ZombieSpawn();
        ZombieSpawn();
        
        score +=1;
    }


}

    
    public void ZombieSpawn()
    {
        int randomPoint = Random.Range(0, spawners.Length);                                                                                 
        Instantiate(ZombiePrefab, spawners[randomPoint].transform.position, spawners[randomPoint].transform.rotation);
        Debug.Log("the monster tag is : " + ZombiePrefab.tag);
        float currentHealthTest = ZombiePrefab.GetComponent<ZombieHealth>().currentHealth;
        Debug.Log("ZombieSpawn Method : " + currentHealthTest); 
        
    }
    public void SpawnTwoMonsters()
    {
        Debug.Log("spanwing Two monsters");
        Instantiate(ZombiePrefab, spawnerPoint.position, spawnerPoint.rotation);
        Instantiate(ZombiePrefab, spawnerPoint.position, spawnerPoint.rotation);
    }

    public bool ShouldSpawn()
    {
        int health = GetComponent<ZombieHealth>().currentHealth ; 
        // int health = ZombiePrefab.GetComponent<ZombieHealth>().health; 
        Debug.Log("the health from shouldSpawn !!! " + health );
        if (health  == 0 )
        {
        return true;
        }else return false;

    }
}
