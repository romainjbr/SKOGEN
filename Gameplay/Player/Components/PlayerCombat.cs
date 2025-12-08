using Skogen.Gameplay.Items;
using Skogen.Gameplay.Items.Weapons;
using UnityEngine;

namespace Skogen.Gameplay.Player.Components
{
    public class PlayerCombat : MonoBehaviour
    {
        private PlayerController player;

        public PlayerCombat (PlayerController player)
        {
            this.player = player;
        }

        public void TrySwapWeapon(Weapon weapon)
        { 
            var inventory = player.Context?.Inventory;
            if (inventory is null) { return; }

            if (inventory.OwnedWeapons.TryGetValue(weapon, out bool hasWeapon) && hasWeapon)
            {
                inventory.EquippedWeapon = weapon;
            }
        }
    }
}