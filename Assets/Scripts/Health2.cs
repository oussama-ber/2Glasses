using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health2 : MonoBehaviour
{
   public int health = 100;
   public RedHealthBar healthBar;
   public  void TakeDamage(int damage)
    {
        // to do if the health <= 50 decrease the power of his gun
        health -= damage ; 
        Debug.Log(health);
        healthBar.SetHealth(health);
        Debug.Log("RED : " + health);
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        //to do effect (system particuls)
        Destroy(gameObject);
        Debug.Log("the enemy died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
