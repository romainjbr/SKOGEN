using UnityEngine;

namespace Skogen.Gameplay.Enemy
{
    [System.Serializable]
    public class EnemyContext
    {
        public EnemyHealth Health { get; set; }
        
        private EnemyController enemy;

        public EnemyContext(EnemyController enemy)
        {
            this.enemy = enemy;

            if (Health == null) { Health = new EnemyHealth(enemy); }
        }
    }
}