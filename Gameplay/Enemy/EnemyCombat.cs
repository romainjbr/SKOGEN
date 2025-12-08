using Skogen.Gameplay.Items.Weapons;
using Skogen.Gameplay.Player;
using UnityEngine;

namespace Skogen.Gameplay.Enemy
{
    public class EnemyCombat : MonoBehaviour
    {
        [Header("Contact Damage")]
        [SerializeField] private int contactDamage = 1;
        [SerializeField] private float contactDamageCooldown = 2f;

        private EnemyController controller;

        private float timeSinceLastContactDamage = 0f;

        public EnemyCombat(EnemyController controller)
        {
            this.controller = controller;
        }

        public void OnDamageArea(GameObject other, bool isEnter)
        {
            if (isEnter)
            {
                if (other.CompareTag("Hit"))
                {
                    controller.Context?.Health?.TakeDamage(1);
                }

                if (other.CompareTag("Player"))
                {
                    DamagePlayer(other, contactDamage);
                }
            }
            else
            {
                if (other.CompareTag("Player") && timeSinceLastContactDamage >= contactDamageCooldown)
                {
                    DamagePlayer(other, contactDamage);
                    timeSinceLastContactDamage = 0f;
                }
            }
        }

        private void DamagePlayer(GameObject playerObject, int damage)
        {
            var player = playerObject.GetComponent<PlayerController>();
            player?.Context?.Health?.TakeDamage(damage);
        }
    }
}