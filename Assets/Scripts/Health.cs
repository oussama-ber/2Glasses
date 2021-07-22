using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Health : MonoBehaviour
{

    public GameOver gameOver;
    public int health = 100;
    public int currentHealth = 100 ;
    public string message; 



  private void OnCollisionEnter(Collision other) {
      if (other.gameObject.tag == "Zombie")
      {
          Die();
      }
  }
//    public  void TakeDamage(int damage)
//     {
//         // to do if the health <= 50 decrease the power of his gun

//         currentHealth -= damage ; 
//         Debug.Log(currentHealth);
//         healthBar.SetHealth(currentHealth);
//           if (currentHealth <= 0)
//         {
//             ZombieDie();
        
//         }
//     }
    // void ZombieDie()
    // {
    //     Debug.Log("Game Over!");
    //     Destroy(gameObject);
    //     SpawnZombie();
        
    // }
    // void SpawnZombie()
    // {
    //      Instantiate(zombiePrefab, zombieSpawnerPoint.position, zombieSpawnerPoint.rotation);
    // }
    public void Die()
    {
        //to do effect (system particuls)
        // if(gameObject.name == "BluePlayer")
        // {
        //     Debug.Log("the Red Player wins");
        //     message = "the Red Player wins!!";
        // }else if (gameObject.name == "RedPlayer")
        // {
        //     Debug.Log("the Blue Player wins");
        //     message= "The Blue Player wins!!";
        // }
        Debug.Log("Game Over!");
        message = "Game Over!";
        Destroy(gameObject);
        
        gameOver.SetUpResult(message);
        
    }
}
