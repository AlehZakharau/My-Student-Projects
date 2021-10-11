using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{
    private TMP_Text timerText;
    
    private int currentSeconds;
    private int minutes;
    private int seconds;

    private string timeText;

    private bool isFinished;

    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        LevelController.Instance.Finish += OnFinish; // При завершениии уровня останавливает подсчет
    }


    // Update is called once per frame
    void Update()
    {
        if (isFinished)
        {
            LevelController.Instance.time = timeText;
            return;
        }
        var levelTime = Time.timeSinceLevelLoad;
        if(levelTime > currentSeconds){
            currentSeconds++;
            GetTimeInMinutes(currentSeconds);
            timeText = GetTime();
            timerText.SetText(timeText);
        }
    }
    /// <summary>
    /// При завершениии уровня останавливает подсчет
    /// </summary>
    private void OnFinish()
    {
        isFinished = true;
    }
    private void GetTimeInMinutes(int sec){
        minutes = sec/60;
        seconds = sec - minutes*60;
    }
    
    private string GetTime(){
        var levelMinute = minutes < 10 ? $"0{minutes}" : $"{minutes}";
        var levelSeconds = seconds < 10 ? $"0{seconds}" : $"{seconds}";
        var time = levelMinute + ":" + levelSeconds;
        return time;
    }
}
