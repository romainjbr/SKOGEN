using UnityEngine;

namespace Skogen.Gameplay.Items.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Throwable : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private int damage = 1;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Setup(Vector3 direction)
        {
            if (rb == null) { return; }
            rb.linearVelocity = direction.normalized * speed;
            Destroy(gameObject, lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Core.Collision.IDamageable>(out var damageable))
            {
                damageable.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}