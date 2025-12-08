using Skogen.Gameplay.Items.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Skogen.Gameplay.Player.Data
{
    [System.Serializable]
    public class PlayerInventory
    {
        [Header("Resources")]
        [SerializeField] private int needleCount;
        public int NeedleCount => needleCount;


        [Header("Weapons")]
        [SerializeField] private Weapon equippedWeapon = Weapon.FIST;

        public Weapon EquippedWeapon
        {
            get => equippedWeapon;
            set
            {
                if (equippedWeapon == value) { return; }
                equippedWeapon = value;
            }
        }

        private readonly Dictionary<Weapon, bool> ownedWeapons = new Dictionary<Weapon, bool>();

        public Dictionary<Weapon, bool> OwnedWeapons => ownedWeapons;

        public void AddNeedle(int amount)
        {
            needleCount += amount;
        }

        public bool HasWeapon(Weapon weapon)
        {
            return ownedWeapons.TryGetValue(weapon, out bool hasWeapon) && hasIt;
        }

        public void UnlockWeapon(Weapon weapon)
        {
            if (weapon == Weapon.FIST) { return; }

            if (ownedWeapons.ContainsKey(weapon))
            {
                if (ownedWeapons[weapon]) { return; }
                ownedWeapons[weapon] = true;
            }
            else
            {
                ownedWeapons.Add(weapon, true);
            }
        }
        public bool TryEquipWeapon(Weapon weapon)
        {
            if (!HasWeapon(weapon)) { return false; }

            EquippedWeapon = weapon;
            return true;
        }
    }
}