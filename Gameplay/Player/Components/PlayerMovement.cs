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