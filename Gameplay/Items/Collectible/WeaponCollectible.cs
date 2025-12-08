using Skogen.Gameplay.Items.Weapons;
using Skogen.Gameplay.Player;
using UnityEngine;

namespace Skogen.Gameplay.Items.Collectibles
{
    public class WeaponCollectible : MonoBehaviour, ICollectible
    {
        [SerializeField] private Weapon weapon;

        public void Collect(PlayerController player)
        {
            if (weapon == Weapon.FIST) { return; }

            player?.Context?.Inventory?.UnlockWeapon(weapon);

            Destroy(gameObject);
        }
    }
}