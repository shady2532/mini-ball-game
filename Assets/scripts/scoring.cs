using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class scoring : MonoBehaviour
{
    public static scoring instance;
    private void Awake()
    {
        instance = this; 
    }

    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highScore = 0;


    public void addScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
        if (highScore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
    

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "Highest Score: " + highScore.ToString();
    }

    
   
}
