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

        [Header("Shooting")]
        [SerializeField] private Transform shootFromPoint;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileSpeed = 10f;
        [SerializeField] private float shootCooldown = 3f;

        private EnemyController controller;

        private float timeSinceLastShot = 0f;
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

        public void OnShootAreaEnter(Transform playerTransform)
        {
            if (timeSinceLastShot < shootCooldown) { return; }
            ThrowProjectile(playerTransform);

            timeSinceLastShot = 0f;
        }

        private void DamagePlayer(GameObject playerObject, int damage)
        {
            var player = playerObject.GetComponent<PlayerController>();
            player?.Context?.Health?.TakeDamage(damage);
        }

        private void ThrowProjectile(Transform target)
        {
            if (projectilePrefab == null || shootFromPoint == null || target == null) { return; }

            var projectile = Instantiate(projectilePrefab, shootFromPoint.position, Quaternion.identity);
            var direction = (target.position - projectile.transform.position).normalized;

            var projectileComp = projectile.GetComponent<Projectile>();
            projectileComp?.Move(direction * projectileSpeed);
        }
    }
}