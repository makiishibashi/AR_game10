using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameObject scoreBoardUI;
    public static int score;
    int reset = 0;



    private void Start()
    {
        gameObject.GetComponent<DartController>().enabled = true;
        scoreBoardUI = GameObject.FindGameObjectWithTag("ScoreCanvas");
        scoreText = GameObject.FindGameObjectWithTag("ScoreOnBanner").GetComponent<TextMeshProUGUI>();

     
       score = PlayerPrefs.GetInt("SCORE", 0);
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();

            PlayerPrefs.SetInt("SCORE", score);
            PlayerPrefs.Save();
     
    }

    public void ResetScore()
    {
        score = 0;
        PlayerPrefs.SetInt("SCORE", 0);
        PlayerPrefs.Save();
    }
}
