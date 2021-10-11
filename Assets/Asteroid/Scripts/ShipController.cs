using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipController : MonoBehaviour
{
    public float speed = 2f;
    public Camera cam;
    public uint lifes = 3;
    public GameObject gameOver;

    private Vector3 movement;
    private Vector2 mousePosition;

    private Rigidbody2D rb;

    public delegate void TryLoseLife();
    public event TryLoseLife LoseLifeUI;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");

        var acceleration = transform.up * (movement.y + 1.5f);
        transform.position += acceleration * speed * Time.deltaTime;
        
        var mouseInput = Input.mousePosition;
        mouseInput.z = 10;
        mousePosition = cam.ScreenToWorldPoint(mouseInput);

    }

    void FixedUpdate()
    {
        var lookDirection = mousePosition - rb.position;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void LoseLife()
    {
        LoseLifeUI?.Invoke();
        lifes -= 1;
        if(lifes == 0) GameOver();
    }

    private void GameOver()
    {
        gameOver.AddComponent<GameOverUiController>().Activate();
        Debug.Log("GameOver");
        Time.timeScale = 0f;
    }
}
