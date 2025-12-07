using Skogen.Gameplay.Player;
using UnityEngine;

namespace Skogen.Gameplay.Player.Components
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerController player;

        public PlayerMovement(PlayerController player)
        {
            this.player = player;
        }

        public bool IsGrounded()
        {
            var col = player.Context.References.Collider;
            
            if (col == null) { return false; }

            var extraHeight = 0.1f;
            var hit = Physics2D.BoxCast(
                col.bounds.center,
                col.bounds.size,
                0f,
                Vector2.down,
                extraHeight,
                player.Context.References.GroundLayer
            );

            return hit.collider != null;
        }

        public void Move(Vector2 input)
        {
            if (player.Context.References.RigidBody == null) { return; }

            var direction = input.x;
            player.Context.Stats.Direction = input;

            var rb = player.Context.References.RigidBody;
            var velocity = new Vector2(direction * player.Context.Stats.WalkSpeed, rb.linearVelocity.y);
            rb.linearVelocity = velocity;
        }
    }
}