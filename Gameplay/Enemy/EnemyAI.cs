using Skogen.Gameplay.Enemy;
using UnityEngine;

namespace Skogen.Gameplay.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private readonly float speed = 2f;
        [SerializeField] private readonly float chaseRange = 5f;
        [SerializeField] private readonly bool moveTowardsTarget = true;

        private Transform target;

        private EnemyController controller;

        public EnemyAI(EnemyController controller)
        {
            this.controller = controller;
        }

        public void Tick(float deltaTime)
        {
            if (target == null) { return; }

            HandleMovement(deltaTime);
        }

        private void HandleMovement(float dt)
        {
            var distanceX = target.position.x - transform.position.x;

            if (Mathf.Abs(distanceX) > chaseRange && moveTowardsTarget)
            {
                var destination = new Vector3(target.position.x, transform.position.y, transform.position.z);
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    destination,
                    speed * dt
                );
            }
        }

        public void OnSightEnter(Transform playerTransform)
        {
            if (target == null)
            {
                target = playerTransform;
            }
        }

        public void OnSightExit(Transform playerTransform)
        {
            if (target == playerTransform)
            {
                target = null;
            }
        }
    }
}
