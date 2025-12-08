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

        // TODO: implement Attack animations
        public void Attack()
        {
            if (player?.Context?.Inventory?.EquippedWeapon == Weapon.STONE)
            {
                ThrowStone();
            }
            else
            {
                // trigger attack animation
            }
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

        public void ThrowStone()
        {
            var prefab = player?.Context?.References.ThrowablePrefab;
            var from = player?.Context?.References.ThrowFrom;

            if (prefab == null || from == null) { return; }

            var stone = Instantiate(prefab, from.position, Quaternion.identity);
            var direction = new Vector3(Mathf.Sign(player.transform.localScale.x), 0f);
            var throwable = stone.GetComponent<Throwable>();
            
            if (throwable != null)
            {
                throwable.Setup(direction);
            }
        }
    }
}