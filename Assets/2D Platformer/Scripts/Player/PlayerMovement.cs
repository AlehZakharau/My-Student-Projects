using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public float jumpForce = 200f;
    public LayerMask groundMask;

    public delegate void TryJump(int levelJump); // Параметром регулируется какой звук проигрывать;
    public event TryJump Jump;

    public delegate void TryDeath();
    public event TryDeath Death;

    private Rigidbody2D rb;
    private PlayerAnimationController playerAnimation;

    private float horizontalInput;
    private Vector2 moveCharacter;

    private bool jump;
    private bool isMoving;
    private bool isGrounded;
    private bool isDoubleJump;
    private bool isFacingRight;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(GetComponent<CircleCollider2D>(), groundMask);

        #region Left Right Input
        
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            if(horizontalInput > 0 && isFacingRight)
                Flip();
            else if(horizontalInput < 0 && !isFacingRight)
                Flip();
            isMoving = true;
            if(isGrounded)
                playerAnimation.Run(true);
        }
        else
        {
            playerAnimation.Run(false);
        }
        #endregion

        
        if (isGrounded)
        {
            isDoubleJump = true;
        }

        #region Jump Input

        if (Input.GetButtonDown("Jump") & isGrounded)
        {
            jump = true;
            Jump?.Invoke(0);
        }
        else if(Input.GetButtonDown("Jump")&& isDoubleJump && !isGrounded)
        {
            isDoubleJump = false;
            jump = true;
            Jump?.Invoke(1);
        }
        #endregion

        moveCharacter.x += horizontalInput;

    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddForce(Vector2.right * horizontalInput * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            isMoving = false;
        }
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    /// <summary>
    /// Поворачивает спрайт
    /// </summary>
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void PlayerDeath()
    {
        Death?.Invoke();
    }
}
