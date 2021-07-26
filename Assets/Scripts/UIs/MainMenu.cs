using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("quit the game from the main menu");
        Application.Quit();
    }
    public void SetActivated(bool isActivated)
    {
        gameObject.SetActive(isActivated);
        Debug.Log("the main menu just loaded");
    }


}
