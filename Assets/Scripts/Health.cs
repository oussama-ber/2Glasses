using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public BlueHealthBar healthBar;
    public int health = 100;
    public int currentHealth = 100 ;
  
   public  void TakeDamage(int damage)
    {
        // to do if the health <= 50 decrease the power of his gun

        currentHealth -= damage ; 
        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
        Debug.Log("BLUE : " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        
        }
    }
    public void Die()
    {
        //to do effect (system particuls)
        Destroy(gameObject);
        Debug.Log("the Red Player wins");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
