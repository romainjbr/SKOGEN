using System;
using UnityEngine;

namespace Skogen.Gameplay.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private int maxHealth = 3;
        private int currentHealth;

        public int MaxHealth => maxHealth;
        public int CurrentHealth => currentHealth;

        public void Initialize(EnemyController controller)
        {
            this.controller = controller;
            currentHealth = maxHealth;
        }
    }
}