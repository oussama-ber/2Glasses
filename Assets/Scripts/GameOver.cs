using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text result;
    public Button replaybutton; 
    public Button quitButton;
    public void SetUpResult(string message)
    {
        gameObject.SetActive(true);
        result.text = message; 
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("replay the game");
    }
    public void QuitGame()
    {
        Debug.Log("quit the game");
        Application.Quit();

    }


}
