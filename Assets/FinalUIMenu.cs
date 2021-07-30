using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalUIMenu : MonoBehaviour
{
     public Text result;
     public Button replayButton;
     public Button quitButton;
   public void SetUpResult(string message)
    {
        Debug.Log("the result is from the ui "+message);
        result.text = message;
        gameObject.SetActive(true);
        // GetComponent<GameOver>().enabled = true;
    }

    // Update is called once per frame
  public void ReplayGame()
    {
        Debug.Log("replay the game, from finaluimenu !!!!!!!!!!!!!!!");
        // mainMenu.SetActivated(false);
        // gameManager.mainMenuShouldLoaded = false;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("the replayer button clicked ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
 
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
