using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MainMenu mainMenu;
    public ResumeMenu resumeMenu;


    public bool mainMenuShouldLoaded = true;


    void Start()
    {

        // Debug.Log("the mainMenuShouldLoaded :" + mainMenuShouldLoaded);
        // if(mainMenuShouldLoaded)
        //     mainMenu.SetActivated(true);
    }

    // public void Replay()
    // {
    //     Debug.Log("replayed the ui should be invisible");
    //     mainMenu.SetActivated(false);
    // }
    private void Update()
    {
        // if (Input.GetKey(KeyCode.Escape))
        // {
        //     resumeMenu.SetVisible();
        // }
    }


}
