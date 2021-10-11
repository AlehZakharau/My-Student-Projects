using Pool;
using UnityEngine;


namespace Alpha.Characters.Enemy
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy", order = 0)]
    public class EnemySO : ScriptableObject
    {
        [SerializeField] private int amountEnemies;
        [SerializeField] private float launchDelay = 2;
        [SerializeField] private float movementDuration = 5; 

        public int AmountEnemies => amountEnemies;
        public float LaunchDelay => launchDelay;
        public float MovementDuration => movementDuration;
    }
}