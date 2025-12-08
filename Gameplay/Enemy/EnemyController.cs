using UnityEngine;

namespace Skogen.Gameplay.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyContext context;
        public EnemyContext Context => context;

        private void Awake()
        {
            if (context == null) { context = new EnemyContext(this); }
        }
    }
}