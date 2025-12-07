using UnityEngine;
using Skogen.Gameplay.Player;

namespace Skogen.Gameplay.Items.Collectibles
{
    public class NeedleCollectible : MonoBehaviour, ICollectible
    {
        private int amount = 0;

        public void Collect(PlayerController player)
        {
            player.Context.Inventory?.AddNeedle(amount);
            Destroy(gameObject);
        }
    }
}