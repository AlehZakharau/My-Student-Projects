using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject switchOff;

    private SpriteRenderer sprite;
    private AudioSource audioSource;

    private bool isOpen;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OpenLevelDoor()
    {
        if (isOpen) return;
        isOpen = true;
        LevelController.Instance.Open();
        switchOff.SetActive(false);
        sprite.enabled = true;
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        OpenLevelDoor();
    }
}
