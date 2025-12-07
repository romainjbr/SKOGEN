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

        private readonly Dictionary<Weapon, bool> ownedWeapons = new Dictionary<Weapon, bool>();

        public Dictionary<Weapon, bool> OwnedWeapons => ownedWeapons;

        public void AddNeedle(int amount)
        {
            needleCount += amount;
        }
    }
}