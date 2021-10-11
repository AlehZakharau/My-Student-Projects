using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollider : MonoBehaviour
{
    public GameObject effect;
    public int lifeAsteroid = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ShipController>().LoseLife();
            lifeAsteroid = 1;
        }
        lifeAsteroid -= 1;
        if (lifeAsteroid != 0) return;
        if (other.CompareTag("Bullet")) ScoreController.Instance.AddScore();
        var damage = Instantiate(effect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
