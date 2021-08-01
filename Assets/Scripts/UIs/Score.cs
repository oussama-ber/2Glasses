using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
  

static public int  currentScore = 0;
public Text ScoreText; 

   
    void Update() {
        ScoreText.text = currentScore.ToString();
        CheckWin();
        // Debug.Log(currentScore);

    }
    public void CheckWin()
    {
        if (currentScore== 3)
        {
            string message = "you won";
            Debug.Log(message);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
