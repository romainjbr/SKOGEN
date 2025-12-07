using Skogen.Gameplay.Player;
using UnityEngine;

namespace Skogen.Gameplay.Player.Components
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerController player;

        private bool canInput = true;
        public bool CanInput => canInput;

        public PlayerInput(PlayerController player)
        {
            this.player = player;
        }

        public void Tick()
        {
            if (player != null && CanInput)
            {
                HandleMovement();
            }
        }

        private void HandleMovement()
        {
            if (player.Context.Movement == null) { return; }

            var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  

            player.Context.Movement.Move(input);  

            if (Input.GetButtonDown("Jump"))
            {
                player.Context.Movement?.Jump();
            }   
        }

        public void DisableInput()
        {
            canInput = false;
        }

        public void EnableInput()
        {
            canInput = true;
        }
    }
}