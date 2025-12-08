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

        public void TakeDamage(int amount)
        {
            if (amount <= 0 || currentHealth <= 0) { return; }

            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            var col = GetComponent<Collider2D>();
            if (col is not null)
            {
                col.enabled = false;
            }
        }
    }
}