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
                HandleWeapons();
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

        private void HandleWeapons()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                player?.Context?.Combat?.TrySwapWeapon(Weapon.FIST);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                player?.Context?.Combat?.TrySwapWeapon(Weapon.STICK);
            }            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                player?.Context?.Combat?.TrySwapWeapon(Weapon.STONE);
            }           
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                player?.Context?.Combat?.TrySwapWeapon(Weapon.KNIFE);
            }            
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                player?.Context?.Combat?.TrySwapWeapon(Weapon.SWORD);
            }            
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                player?.Context?.Combat?.TrySwapWeapon(Weapon.AXE);
            }            
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                player?.Context?.Combat?.TrySwapWeapon(Weapon.BREAD);
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