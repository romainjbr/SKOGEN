using UnityEngine;

namespace Skogen.Gameplay.Items.Pushable
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PushableObject : MonoBehaviour
    {
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        public void ApplyPush(Vector2 force)
        {
            rb?.AddForce(force, ForceMode2D.Impulse);
        }
    }
}