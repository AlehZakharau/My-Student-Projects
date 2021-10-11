using System;
using Alpha.Characters;
using Pool;
using UnityEngine;

namespace Alpha
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 3f;
        [SerializeField] private BulletPoolSO bulletPool;

        [SerializeField] private float lifeTimer = 5f;
        [SerializeField] private int obstacleLayer;
        private float timer;

        public int EnemyLayer { get; set; }
        public float BulletSpeed { get; set; }

        private void OnDisable()
        {
            timer = 0f;
        }

        private void Update()
        {
            transform.position += transform.forward * bulletSpeed * Time.deltaTime;

            timer += Time.deltaTime;

            if (timer > lifeTimer)
            {
                bulletPool.Return(this);
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log($"other layer: {other.gameObject.layer} bullet enemy layer{EnemyLayer}");
            if (other.gameObject.layer == EnemyLayer)
            {
                //Debug.Log($"Enemy detected");
                other.GetComponent<IHealth>().Hit();
                bulletPool.Return(this);
            }
            else if(other.gameObject.layer == obstacleLayer)
            {
                bulletPool.Return(this);
            }
        }
    }
}