using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;
    private PlayerMovement movement;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        movement.Jump += Jump;
        movement.Death += Death;
    }

    private void Jump(int levelJump)
    {
        audioSource.clip = clips[levelJump];
        audioSource.Play();
    }

    private void Death()
    {
        audioSource.clip = clips[2];
        audioSource.Play();
    }
}
