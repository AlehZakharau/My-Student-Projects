using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidGenerator : MonoBehaviour
{
    public float radius = 200f;
    public float asteroidForce = 20f;
    public float generationTime = 1f;
    public int[] randomizeForce = new int[]{-3,3};
    
    public GameObject[] asteroids;

    private float generateTime;

    // Update is called once per frame
    void Update()
    {
        generateTime += Time.deltaTime;
        if (generateTime > generationTime)
        {
            InstantiatingAsteroid();
            generateTime = 0;
        }
        

    }

    private float GenerateAngle()
    {
        return Random.Range(1, 360);
    }

    private Vector3 GetStartPoint(float angle)
    {
        var x = Mathf.Cos(angle) * radius + transform.position.x;
        var y = Mathf.Sin(angle) * radius + transform.position.y;
        
        var startPoint = new Vector3(x, y, 0);

        return startPoint;
    }
    private Vector3 GetFinishPoint(float angle)
    {
        var randomX = Random.Range(-10, 10);
        var randomY = Random.Range(-10, 10);
        var finishPoint = new Vector3(transform.position.x + randomX, transform.position.y + randomY, 0);

        return finishPoint;
    }

    private void InstantiatingAsteroid()
    {
        var angle = GenerateAngle();
        var startPoint = GetStartPoint(angle);
        var finishPoint = GetFinishPoint(angle);

        
        var randomAsteroid = Random.Range(0, asteroids.Length);    //Random sprite
        var asteroidGenerated = Instantiate(asteroids[randomAsteroid], startPoint, Quaternion.identity);
        var rbAsteroid = asteroidGenerated.GetComponent<Rigidbody2D>();
        
        var addRandomizeForce = (Random.Range(randomizeForce[0], randomizeForce[1]) + 0.1f) * asteroidForce * 0.1f;    //Random Force
        rbAsteroid.AddForce((startPoint - finishPoint) * (-asteroidForce + addRandomizeForce), ForceMode2D.Impulse);
    }
}
