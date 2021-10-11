using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUiController : MonoBehaviour
{
    private AudioSource buttonSound;

    private void Awake()
    {
        buttonSound = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        buttonSound.Play();
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        buttonSound.Play();
        Debug.Log("Exit");
        Application.Quit();
    }
}
