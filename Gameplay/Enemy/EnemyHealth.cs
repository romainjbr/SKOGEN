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

        [Header("Drop")]
        [SerializeField] private GameObject needlePrefab;
        [SerializeField] private float dropHeightOffset = 3f;

        private EnemyController controller;
        
        public EnemyHealth(EnemyController controller)
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
            DropLoot();

            var col = GetComponent<Collider2D>();
            if (col is not null)
            {
                col.enabled = false;
            }
        }

        private void DropLoot()
        {
            if (needlePrefab == null) { return; }

            var spawnPos = transform.position + Vector3.up * dropHeightOffset;
            Instantiate(needlePrefab, spawnPos, transform.rotation);
        }
    }
}