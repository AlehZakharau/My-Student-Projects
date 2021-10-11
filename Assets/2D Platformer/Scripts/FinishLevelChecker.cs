using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelChecker : MonoBehaviour
{
    public GameObject closedDoor;

    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    private AudioSource audioSource;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        LevelController.Instance.OpenDoor += OpenDoor;
    }

    private void OpenDoor()
    {
        closedDoor.SetActive(false);
        sprite.enabled = true;
        boxCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        LevelController.Instance.FinishLevel();
        if(!audioSource.isPlaying)audioSource.Play();
    }
}
