using System;
using UnityEngine;
using UnityEngine.AI;

namespace Alpha.Characters.Enemy
{
    public class GeorgeMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMesh;
        [SerializeField] private Transform player;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject weaponObject;
        [SerializeField] private float delayBetweenShoots;
        
        private static readonly int Fire = Animator.StringToHash("Fire");


        private IWeapon weapon;
        private float timer = 0;
        public Transform Player
        {
            get => player;
            set => player = value;
        }

        private void Start()
        {
            weapon = weaponObject.GetComponent<IWeapon>();
            timer = delayBetweenShoots - 1;
        }

        private void Update()
        {
            
            navMesh.SetDestination(player.position);
            if (navMesh.remainingDistance < navMesh.stoppingDistance)
            {
                timer += Time.deltaTime;
                if (timer > delayBetweenShoots)
                {
                    timer = 0;
                    animator.SetLayerWeight(Fire, 1);
                    animator.SetTrigger(Fire);
                    weapon.Fire(player.gameObject);
                }
            }

            transform.LookAt(player.position);
        }
    }
}