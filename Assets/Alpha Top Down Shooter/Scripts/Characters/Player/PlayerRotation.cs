using System;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private PlayerInput playerInput;

        private Vector2 cursorPosition;

        public Vector3 CursorPos { get; set; }

        private void Update()
        {
            cursorPosition = playerInput.Input.Player.CursorPosition.ReadValue<Vector2>();

            CursorPos = CursorRotation();
            Rotate(CursorPos);
        }

        public Vector3 CursorRotation()
        {
            var newPos = new Vector3(cursorPosition.x, cursorPosition.y, camera.transform.position.y );
            var mouseWorldPosition = camera.ScreenToWorldPoint(newPos) - transform.position;
            //Debug.Log($"mouseDirection {mouseWorldPosition}  {camera.ScreenToWorldPoint(newPos)} ");
            return mouseWorldPosition;
        }
        
        private void Rotate(Vector3 direction)
        {
            direction.y = 0;
            if(Mathf.Abs(direction.x) < 1 && Mathf.Abs(direction.z) < 1) return;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}