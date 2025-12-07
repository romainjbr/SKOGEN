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

        public void AddNeedle(int amount)
        {
            needleCount += amount;
        }
    }
}