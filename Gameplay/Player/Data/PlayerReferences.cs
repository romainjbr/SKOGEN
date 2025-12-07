using Skogen.Gameplay.Player;
using UnityEngine;

namespace Skogen.Gameplay.Player.Data
{
    [System.Serializable]
    public class PlayerReferences
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private Collider2D collider;
        [SerializeField] private LayerMask groundLayer;

        public Rigidbody2D RigidBody => rigidBody;
        public Collider2D Collider => collider;
        public LayerMask GroundLayer => groundLayer;

        private PlayerController player;
        
        public PlayerReferences(PlayerController player)
        {
            this.player = player;

            if (rigidBody == null)
            {
                rigidBody = player.GetComponent<Rigidbody2D>();
            }

            if (collider == null)
            {
                collider = player.GetComponent<Collider2D>();
            }
        }
    }
}
