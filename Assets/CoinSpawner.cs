using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // public Transform spawnerPoint;
    public GameObject[] spawners;
    public int score = 0;
    void Start()
    {
        spawners = new GameObject[3];
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        // float currentHealthTest = CoinPrefab.GetComponent<ZombieHealth>().currentHealth;
        // SpawnCoin();
        Debug.Log("current Score " + Score.currentScore);
    }

    void Update()
    {
        // float currentHealthTest = CoinPrefab.GetComponent<ZombieHealth>().currentHealth;

        // if (Score.currentScore == (score + 1))
        // {
        //     Debug.Log("current Score " + Score.currentScore);
        //     Debug.Log("spawning a zombie!!!");
        //     SpawnCoin();
        //     score += 1;
        // }
    }
    public void SpawnCoin()
    {
        int randomPoint = Random.Range(0, spawners.Length);
        // Instantiate(CoinPrefab, spawners[randomPoint].transform.position, spawners[randomPoint].transform.rotation);
        // Debug.Log("the coin tag is : " + CoinPrefab.transform.tag);
        // float currentHealthTest = CoinPrefab.GetComponent<ZombieHealth>().currentHealth;
        // Debug.Log("ZombieSpawn Method : " + currentHealthTest);

    }
    // public void SpawnTwoMonsters()
    // {
    //     Debug.Log("spanwing Two monsters");
    //     Instantiate(CoinPrefab, spawnerPoint.position, spawnerPoint.rotation);
    //     Instantiate(CoinPrefab, spawnerPoint.position, spawnerPoint.rotation);
    // }

    public bool ShouldSpawn()
    {
        int health = GetComponent<ZombieHealth>().currentHealth;
        // int health = ZombiePrefab.GetComponent<ZombieHealth>().health; 
        Debug.Log("the health from shouldSpawn !!! " + health);
        if (health == 0)
        {
            return true;
        }
        else return false;

    }
    public Vector3 ChangePosition()
    {
        int randomPoint = Random.Range(0, spawners.Length);
        return spawners[randomPoint].transform.position;

    }
//     public GameObject RandomIndex()
//     {
// int randomPoint = Random.Range(0, spawners.Length);
//        return  spawners[randomPoint];
         
//     }
}
