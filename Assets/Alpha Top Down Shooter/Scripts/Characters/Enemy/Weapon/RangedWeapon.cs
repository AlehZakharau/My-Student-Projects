using System;
using System.Collections;
using Pool;
using UnityEngine;

namespace Alpha.Characters.Enemy
{
    public class RangedWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private BulletPoolSO bulletPool;
        [SerializeField] private float bulletSpeed;
        

        
        
        public void Fire(GameObject player)
        {
            var bullet = bulletPool.Request();
            bullet.transform.position = transform.position;
            bullet.EnemyLayer = 7;
            bullet.BulletSpeed = bulletSpeed;
            bullet.transform.LookAt(player.transform.position + new Vector3(0, 0.25f,0));
            //bullet.transform.eulerAngles += new Vector3(-90,0,180);
        }
    }
}