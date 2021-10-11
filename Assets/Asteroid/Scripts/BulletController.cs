using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float BulletLifeTime = 10f;

    private float lifeTime;
    private void Update()
    {
        lifeTime += Time.deltaTime;

        if (lifeTime > BulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) return;
        Destroy(gameObject);
    }
}
