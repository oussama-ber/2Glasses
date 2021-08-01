using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int health = 100;
    public int currentHealth = 100;
    void OnEnable()
    {
         currentHealth = 100;
    }
    public void TakeDamage(int  damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            EnemyDie();
        }
    }
    void EnemyDie()
    {
        Debug.Log("Game Over!");
        Score.currentScore += 1;
        Debug.Log("the current score is : " + Score.currentScore);
        Destroy(gameObject);
    }
}
