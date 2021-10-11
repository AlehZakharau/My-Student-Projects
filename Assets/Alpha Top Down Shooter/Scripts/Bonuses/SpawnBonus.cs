using System;
using System.Collections;
using Alpha.Bonuses;
using Alpha.Characters;
using Pool;
using UnityEngine;


namespace Alpha.Bonuses
{
    public class SpawnBonus : MonoBehaviour
    {
        [SerializeField] private BonusPoolSO bonusPool;
        [SerializeField] private float delayBetweenSpawn;
        [SerializeField] private float highBonusSpawn;

        private Vector3 spawnPosition;

        private Bonus currentBonus;
        private void Start()
        {
            spawnPosition = transform.position;
            spawnPosition.y += highBonusSpawn;
            StartCoroutine(BonusReload());
        }

        private IEnumerator BonusReload()
        {
            yield return new WaitForSeconds(delayBetweenSpawn);
            currentBonus = bonusPool.Request();
            currentBonus.transform.position = spawnPosition;
            currentBonus.AutoSpawn = true;
            currentBonus.onPickUp += PickUp;
        }
        
        

        public void PickUp()
        {
            currentBonus.onPickUp -= PickUp;
            StartCoroutine(BonusReload());
        }
    }
}