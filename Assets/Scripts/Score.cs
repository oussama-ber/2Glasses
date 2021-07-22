using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  

static public int  currentScore = 0;
public Text ScoreText; 

   
    void Update() {
        ScoreText.text = currentScore.ToString();
        // Debug.Log(currentScore);
    }
}
