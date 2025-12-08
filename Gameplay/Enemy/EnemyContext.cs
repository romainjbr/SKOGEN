using UnityEngine;

namespace Skogen.Gameplay.Enemy
{
    [System.Serializable]
    public class EnemyContext
    {
        public EnemyHealth Health { get; set; }
        public EnemyCombat Combat { get; set; }
        public EnemyAI AI { get; set; }
        
        private EnemyController enemy;

        public EnemyContext(EnemyController enemy)
        {
            this.enemy = enemy;

            if (Health == null) { Health = new EnemyHealth(enemy); }
            if (Combat == null) { Combat = new EnemyCombat(enemy); }
            if (AI == null) { AI = new EnemyAI(enemy); }
        }
    }
}