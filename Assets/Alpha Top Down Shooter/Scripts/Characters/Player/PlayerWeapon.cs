using System;
using System.Collections.Generic;
using System.Linq;
using Alpha.Characters.Enemy;
using Alpha.UI;
using Characters.Player;
using Pool;
using UnityEngine;
using UnityEngine.Rendering;

namespace Alpha.Characters
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private BulletPoolSO bulletPool;
        [SerializeField] private AudioSource shootSound;
        [SerializeField] private ParticleSystem shootParticle;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerRotation playerRotation;

        [SerializeField] private int ammo = 20;
        [SerializeField] private int maxAmmo = 50;
        [SerializeField] private InfoUI info;
        
        private static readonly int Fire1 = Animator.StringToHash("Fire");
        
        public int Ammo
        {
            get => ammo;
            set
            {
                ammo = value;
                if(ammo > maxAmmo)
                    ammo = maxAmmo;
                info.UpdateAmmoText(ammo);
            }
        }

        private void Start()
        {
            bulletPool.PreWarm(20);
        }

        private void Update()
        {
            var fire = playerInput.Input.Player.Fire.triggered;


            var cursorDirection = playerRotation.CursorPos;
            Fire(cursorDirection, fire);
        }
        
        private void Fire(Vector3 direction, bool pressed)
        {
            if(!pressed) return;
            {
                Fire(direction);
                animator.SetLayerWeight(1, 1);
                animator.SetTrigger(Fire1);
            }
        }


        public void Fire(Vector3 direction)
        {
            if(ammo < 1) return;
            ammo--;
            info.UpdateAmmoText(ammo);
            var bullet = bulletPool.Request();
            bullet.transform.position = transform.position;
            bullet.EnemyLayer = 6; 
            bullet.transform.rotation = Quaternion.LookRotation(direction);
            shootSound.Play();
            shootParticle.Play();
        }

        public void AddAmmo(int addAmmo)
        {
            Ammo += addAmmo;
            //Debug.Log($"'Ammo : {ammo}, AddAmmo : {addAmmo}");
            info.UpdateAmmoText(ammo);
        }


        
    }
}