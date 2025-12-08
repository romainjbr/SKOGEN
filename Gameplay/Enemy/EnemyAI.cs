using Skogen.Gameplay.Enemy;
using UnityEngine;

namespace Skogen.Gameplay.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private EnemyController controller;

        public EnemyAI(EnemyController controller)
        {
            this.controller = controller;
        }
    }
}
