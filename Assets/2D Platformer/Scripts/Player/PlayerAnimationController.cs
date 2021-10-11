using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;
    private CameraShake cameraShake;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        cameraShake = GetComponent<CameraShake>();
    }

    private void Start()
    {
        movement.Jump += Jump;
        movement.Death += Death;
    }

    private void Jump(int levelJump)
    {
        animator.SetTrigger("Jump");
    }
    
    public void Run(bool isRunning)
    {
        animator.SetBool("Run", isRunning);
    }

    private void Death()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        movement.enabled = false;
        animator.SetTrigger("Death");
        var timeDelay = animator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(PlayAgain(timeDelay));
        StartCoroutine(cameraShake.ShakeCamera(timeDelay));
    }

    private IEnumerator PlayAgain(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Well");
    }
}
