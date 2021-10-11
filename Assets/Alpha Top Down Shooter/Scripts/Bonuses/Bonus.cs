using System;
using Pool;
using UnityEngine;

namespace Alpha.Bonuses
{
    public abstract class Bonus : MonoBehaviour
    {
        [SerializeField] protected int addPoints;
        [SerializeField] private float yAngle;
        [SerializeField] private BonusPoolSO bonusPool;
        [SerializeField] private ParticleSystem spawnEffect;

        public SpawnBonus SpawnBonus { get; set; }
        public bool AutoSpawn { get; set; }

        public event Action onPickUp;

        private void OnEnable()
        {
            spawnEffect.Play();
        }

        private void Update()
        {
            transform.Rotate(0, yAngle, 0, Space.Self);
        }

        protected virtual void AddPoint(GameObject player)
        {
            
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                onPickUp?.Invoke();
                // if(AutoSpawn)
                //     SpawnBonus.PickUp();
                AddPoint(other.gameObject);
                AutoSpawn = false;
                bonusPool.Return(this);
            }
        }
    }
}