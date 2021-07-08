using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public HealthBar healthBar;
    public GameOver gameOver;
    public int health = 100;
    public int currentHealth = 100 ;
    public string message; 
  
   public  void TakeDamage(int damage)
    {
        // to do if the health <= 50 decrease the power of his gun

        currentHealth -= damage ; 
        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
          if (currentHealth <= 0)
        {
            Die();
        
        }
    }
    public void Die()
    {
        //to do effect (system particuls)
        if(gameObject.name == "BluePlayer")
        {
            Debug.Log("the Red Player wins");
            message = "the Red Player wins!!";
        }else if (gameObject.name == "RedPlayer")
        {
            Debug.Log("the Blue Player wins");
            message= "The Blue Player wins!!";
        }
        Destroy(gameObject);
        
        gameOver.SetUpResult(message);
        
    }
}
