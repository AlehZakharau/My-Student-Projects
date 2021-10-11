using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunContoller : MonoBehaviour
{
    public GameObject bullet;

    public float bulletForce = -200f;
    public uint ammoCapacity = 5;

    public delegate void TryShoot();
    public event TryShoot Launch;
    
    public delegate void TryReload();
    public event TryReload ReloadBullets;

    private AudioSource shootSound;
    private ShipController ship;

    private void Awake()
    {
        ship = GetComponent<ShipController>();
        shootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ship.lifes != 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                LaunchBullet();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Reload();
            }
        }
    }


    private void LaunchBullet()
    {
        if(ammoCapacity == 0) return;
        ammoCapacity -= 1;
        var bulletActive = Instantiate(bullet, transform.position, transform.rotation);
        var rbBull = bulletActive.GetComponent<Rigidbody2D>();
        rbBull.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        shootSound.Play();
        Launch?.Invoke();
    }

    private void Reload()
    {
        ammoCapacity = 5;
        ReloadBullets?.Invoke();
    }
}
