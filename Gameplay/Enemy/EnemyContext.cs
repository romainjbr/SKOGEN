using UnityEngine;

namespace Skogen.Gameplay.Enemy
{
    [System.Serializable]
    public class EnemyContext
    {
        private EnemyController enemy;

        public EnemyContext(EnemyController enemy)
        {
            this.enemy = enemy;
        }
    }
}