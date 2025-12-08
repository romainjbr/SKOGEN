using UnityEngine;

namespace Skogen.Core.Collision
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionTrigger : MonoBehaviour
    {
        [Header("Collider")]
        [SerializeField] private string colliderName;

        [Header("Target")]
        [SerializeField] private MonoBehaviour collisionHandlerSource;

        private ICollisionHandler handler;

        private void Awake()
        {
            if (string.IsNullOrWhiteSpace(colliderName))
            {
                colliderName = gameObject.name;
            }

            if (collisionHandlerSource == null)
            {
                collisionHandlerSource = GetComponentInParent<MonoBehaviour>();
            }
            if (collisionHandlerSource is ICollisionHandler h)
            {
                handler = h;
            }
            else if (collisionHandlerSource != null)
            {
                return;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (handler == null) { return; }
            handler.CollisionEnter(colliderName, other.gameObject, true);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (handler == null) { return; }
            handler.CollisionEnter(colliderName, other.gameObject, false);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (handler == null) { return; }
            handler.CollisionExit(colliderName, other.gameObject);
        }
    }
}
