using System;
using System.Collections;
using Alpha.Data;
using Alpha.UI;
using Pool;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Alpha.Characters
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int damagePoints;
        [SerializeField] private int scoreValue;
        [SerializeField] private EnemyPoolSO poolSo;
        [SerializeField] private Enemy.Enemy enemy;
        [SerializeField] private BonusPoolSO[] bonusPool;
        [SerializeField] private EffectPoolSO effectPool;
        [SerializeField] private bool explosionDeath;
        [SerializeField] private MeshRenderer meshRenderer;
        
        
        private int healthPoints = 100;
        private MaterialPropertyBlock matBlock;
        private static readonly int Health = Shader.PropertyToID("_Health");
        private void Awake()
        {
            matBlock = new MaterialPropertyBlock();
        }
        
        public InfoUI Ui { get; set; }
        private int health;

        private void OnEnable()
        {
            health = healthPoints;
            meshRenderer.GetPropertyBlock(matBlock);
            matBlock.SetFloat(Health, 100 * 0.01f);
            meshRenderer.SetPropertyBlock(matBlock);
        }

        public void Hit()
        {
            health -= damagePoints;
            
            meshRenderer.GetPropertyBlock(matBlock);
            matBlock.SetFloat(Health, health * 0.01f);
            meshRenderer.SetPropertyBlock(matBlock);
            if (health < 1)
            {
                //Debug.Log("Enemy Dead");
                Dropdown();
                Ui.UpdateScoreText(scoreValue);
                var effect = effectPool.Request();
                effect.transform.position = transform.position;
                if (explosionDeath != true)
                    effect.Play();
                else
                    effect.Play(4);
                poolSo.Return(enemy);

            }
        }

        private void Dropdown()
        {
            var chance = Random.Range(0, 25);
            if (chance == 1)
            {
                var a = Random.Range(0, 2);
                var bonus = bonusPool[a].Request();
                bonus.transform.position = transform.position;
            }
        }
    }
}