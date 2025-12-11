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
        
        public void SetPushable(PushableObject pushable)
        {
            player.Context.References.CurrentPushable = pushable;
        }

        public void ClearPushable(PushableObject pushable)
        {
            if (player.Context.References.CurrentPushable == pushable)
            {
                player.Context.References.CurrentPushable = null;
            }
        }

        // TODO: Implement animation
        public void StartPush()
        {
        }

        // TODO: Implement animation
        public void StopPush()
        {       
        }
    }
}