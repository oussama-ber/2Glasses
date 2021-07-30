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
    public GameManager gameManager;
    public MainMenu mainMenu;

    public void SetUpResult(string message)
    {
        gameObject.SetActive(true);
        GetComponent<GameOver>().enabled = true;
        result.text = message;
    }

    public void ReplayGame()
    {
        // mainMenu.SetActivated(false);
        // gameManager.mainMenuShouldLoaded = false;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("the replayer button clicked ");
        SceneManager.LoadScene(1);
        // mainMenu.SetActivated(false);
        // gameManager.mainMenuShouldLoaded = false;
        

        gameObject.SetActive(false);
        Debug.Log("replay the game");
    }
    public void QuitGame()
    {
        Debug.Log("quit the game");
        Application.Quit();

    }


}
