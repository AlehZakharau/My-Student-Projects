using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : SingletonAsComponent<ScoreController>
{
    public static ScoreController Instance
    {
        get { return ((ScoreController)_Instance); }
        set { _Instance = value; }
    }
    
    private TextMeshProUGUI scoreTMP;

    private TMP_Text scoreText;

    private uint score;

    private void Awake()
    {
        scoreTMP = GetComponent<TextMeshProUGUI>();
        scoreText = scoreTMP.GetComponent<TMP_Text>();
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
    
}
