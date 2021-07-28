using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int health = 100;
    public int currentHealth = 100;






    void OnEnable()
    {
         currentHealth = 100;
        // Debug.Log("my current health is Onenable:" + currentHealth);
    }
    void Start()
    {
        currentHealth = 100;
        Debug.Log("my current health is Onenable:" + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        // to do if the health <= 50 decrease the power of his gun

        currentHealth -= damage;
        Debug.Log("my health is : " + currentHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            die();

        }
    }
    void die()
    {
        Debug.Log("Game Over!");
        // Score.currentScore += 1;
        // Debug.Log("the current score is : " + Score.currentScore);
        Destroy(gameObject);
    }
}
