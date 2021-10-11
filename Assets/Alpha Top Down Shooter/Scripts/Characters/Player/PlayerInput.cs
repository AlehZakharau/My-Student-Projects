using System;
using Player;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerInput : MonoBehaviour
    {

        private AlphaInput alphaInput;

        public AlphaInput Input => alphaInput;


        private void Awake()
        {
            alphaInput = new AlphaInput();
        }
        
        
        public void OnEnable()
        {
            alphaInput.Enable();
        }

        public void OnDisable()
        {
            alphaInput.Disable();
        }
    }
}