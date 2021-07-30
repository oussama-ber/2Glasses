using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterMenu : MonoBehaviour
{
      public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("quit the game from the main menu");
        Application.Quit();
    }
    public void ReplayGame()
    {
        Debug.Log("game has been replayed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
