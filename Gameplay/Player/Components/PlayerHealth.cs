using UnityEngine;

namespace Skogen.Gameplay.Player.Components
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 3;
        [SerializeField] private int currentHealth;

        private PlayerController player;

        public int MaxHealth => maxHealth;
        public int CurrentHealth => currentHealth;

        public PlayerHealth(PlayerController player)
        {
            this.player = player;
            currentHealth = maxHealth;
        }

        public void Heal(int amount)
        {
            if (amount <= 0 || (amout + currentHealth < maxHealth)) { return; }

            currentHealth += amount;
        }
    }
}