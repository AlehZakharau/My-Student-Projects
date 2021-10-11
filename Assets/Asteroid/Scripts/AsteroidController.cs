using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : MonoBehaviour
{
    public float speed = 20f;
    public float asteroidLifeTime = 20f;

    private float lifeTime;

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;

        if (lifeTime > asteroidLifeTime)
        {
            Destroy(gameObject);
        }
        var angle = Random.Range(0.01f, 1);
        transform.Rotate(0, 0, angle);
    }
    

}
