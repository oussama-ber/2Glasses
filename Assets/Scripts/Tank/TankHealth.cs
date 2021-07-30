using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int health = 100;
    public int currentHealth = 100;
    public GameOver gameOver;
    public FinalUIMenu finalUIMenu;






    void OnEnable()
    {
         currentHealth = 100;
        //  finalUIMenu =GetComponent<FinalUIMenu>();
        // Debug.Log("my current health is Onenable:" + currentHealth);
    }
    void Start()
    {
        currentHealth = 100;
        // Debug.Log("my current health is Onenable:" + currentHealth);
        //    finalUIMenu =GetComponent<FinalUIMenu>();
    }

    public void TakeDamage(int damage)
    {
        // to do if the health <= 50 decrease the power of his gun

        currentHealth -= damage;
        // Debug.Log("my health is : " + currentHealth);
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
        LoadNextScene();
        // GameOverUI();
    }
     public void GameOverUI()
    {
        Debug.Log("Game Over!");
        string message = "Game Over!";
        Destroy(gameObject);
        Score.currentScore = 0;
        // GetComponent<GameOver>().enabled = true;
        // GetComponent<FinalUIMenu>().enabled = true;
        // finalUIMenu = GetComponent<FinalUIMenu>();
        // finalUIMenu.SetUpResult(message);

        gameOver.SetUpResult(message);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
