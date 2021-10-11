using System;
using System.Collections;
using Alpha.Characters;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = Characters.Player.PlayerInput;
#pragma warning disable 108,114

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float smoothVelocity = 0.2f;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Camera camera;
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerWeapon playerWeapon;
        
        
        private static readonly int RunningLR = Animator.StringToHash("RunLR");
        private static readonly int RunningFB = Animator.StringToHash("RunFB");

        public PlayerWeapon PlayerWeapon => playerWeapon;

        private Vector2 currentInput;
        private Vector2 SmoothInput;

        public void Update()
        {
            var move = playerInput.Input.Player.Move.ReadValue<Vector2>();

            Move(move);
            CheckBorders();
        }


        private void Move(Vector2 direction)
        {
             var animationRotation = 
                 Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
            animator.SetFloat( RunningFB, animationRotation.x);
            animator.SetFloat(RunningLR, animationRotation.z);
            currentInput = Vector2.SmoothDamp(
                currentInput, direction, ref SmoothInput, smoothVelocity);
            var move = new Vector3(currentInput.y, 0, -currentInput.x);
            //Debug.Log($"Move: {move}");
            transform.position += move * moveSpeed * Time.deltaTime;
        }

        private void CheckBorders()
        {
            #region Borders
        
            var shipScreenPos = camera.WorldToScreenPoint(transform.position);
            //Debug.Log($"{shipScreenPos.y} : {Camera.main.ScreenToWorldPoint(shipScreenPos).z}");
        
            if (shipScreenPos.x > Screen.width)
            {
                shipScreenPos.x = Screen.width;
                transform.position = new Vector3(camera.ScreenToWorldPoint(shipScreenPos).x, 0, transform.position.z);
            }
            else if (shipScreenPos.x < 0)
            {
                shipScreenPos.x = 0;
                transform.position = new Vector3(camera.ScreenToWorldPoint(shipScreenPos).x, 0, transform.position.z);
            }
        
            if (shipScreenPos.y > Screen.height)
            {
                shipScreenPos.y = Screen.height;
                transform.position = new Vector3(transform.position.x,0, camera.ScreenToWorldPoint(shipScreenPos).z);
            }
            else if (shipScreenPos.y < 0)
            {
                shipScreenPos.y = 0;
                transform.position = new Vector3(transform.position.x,0, camera.ScreenToWorldPoint(shipScreenPos).z);
            }
            #endregion
        }
    }
}