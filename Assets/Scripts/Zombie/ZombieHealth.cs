using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public GameOver gameOver;
    public int health = 100;
    public int currentHealth = 100;
    public string message;


    public Transform zombieSpawnerPoint;
    public GameObject zombiePrefab;
    public ZombieSpawner spawner;


    void OnEnable()
    {
        int currentHealth = 100;
        Debug.Log(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        // to do if the health <= 50 decrease the power of his gun

        currentHealth -= damage;
        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            ZombieDie();

        }
    }
    void ZombieDie()
    {
        Debug.Log("Game Over!");
        Score.currentScore += 1;
        Debug.Log("the current score is : " + Score.currentScore);
        Destroy(gameObject);
    }


}
