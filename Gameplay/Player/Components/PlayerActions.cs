using Skogen.Gameplay.Items.Pushable;
using UnityEngine;

namespace Skogen.Gameplay.Player.Components
{
    public class PlayerActions : MonoBehaviour
    {
        private PlayerController player;

        public PlayerActions(PlayerController player)
        {
            this.player = player;
        }
    }
}