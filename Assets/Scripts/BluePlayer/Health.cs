using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public GameOver gameOver;
    public int health = 100;
    public int currentHealth = 100;
    public string message;
    public GameObject zombie;
    //UIs
    public GameObject staminaBar;
    public GameObject staminaText;
    public GameObject score;
    public GameObject scoreText;

    [SerializeField] public ParticleSystem crushParticles;
    private void Awake()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Die();
        }
    }
    public void Die()
    {

        crushParticles.Play();
        GetComponent<Player1Movement>().enabled = false;
        GetComponent<MouseRotate>().enabled = false;
        zombie.GetComponent<MoveUsingRaycast>().enabled = false;
        zombie.GetComponent<MoveAlong>().enabled = false;
        // Make the UIs invisible
        staminaBar.SetActive(false);
        staminaText.SetActive(false);
        score.SetActive(false);
        scoreText.SetActive(false);




        Invoke("GameOverUI", 2f);

    }
    public void GameOverUI()
    {
        Debug.Log("Game Over!");
        message = "Game Over!";
        Destroy(gameObject);
        Score.currentScore = 0;
        gameOver.SetUpResult(message);
    }
}
