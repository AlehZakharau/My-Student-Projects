using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private AudioSource buttonSound;

    private void Awake()
    {
        buttonSound = GetComponent<AudioSource>();
    }

    public void LoadLevel()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Play");
    }

    public void Exit()
    {
        buttonSound.Play();
        Debug.Log("Exit");
        Application.Quit();
    }
}
