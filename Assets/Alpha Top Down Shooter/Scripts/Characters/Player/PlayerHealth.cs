using System;
using Alpha.Characters;
using Alpha.UI;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int healthPoints = 100;
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private Material healthBar;
        
        [SerializeField] private EndGameMenuUI endGameMenuUi;
        [SerializeField] private AudioSource deathSound;

        
        private static readonly int Health = Shader.PropertyToID("_Health");


        private void Start()
        {
            healthBar.SetFloat(Health, maxHealth * 0.01f);
        }

        public int HealthPoints
        {
            get => healthPoints;
            set
            {
                healthPoints = value;
                if(healthPoints > maxHealth)
                    healthPoints = maxHealth;
            }
        }

        public void Hit()
        {
            healthPoints -= 10;
            healthBar.SetFloat(Health, healthPoints * 0.01f);
            //Debug.Log($"Health: {healthPoints}");
            if (healthPoints < 1)
            {
                deathSound.Play();
                endGameMenuUi.FinishGame(false);
                this.enabled = false;
            }
        }

        public void AddHealth(int addHealth)
        {
            HealthPoints += addHealth;
            //Debug.Log($"Health: {healthPoints}");
            healthBar.SetFloat(Health, healthPoints * 0.01f);
            
        }
    }
}