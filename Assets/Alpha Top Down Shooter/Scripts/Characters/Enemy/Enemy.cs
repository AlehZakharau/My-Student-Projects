using System;
using System.Collections.Generic;
using Characters.Enemy;
using Pool;
using UnityEngine;
using UnityEngine.AI;

namespace Alpha.Characters.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public VictoryCondition victoryCondition;
        public NavMeshAgent navMeshAgent;
        public GeorgeMovement georgeMovement;
        public EnemyHealth enemyHealth;
    }
}