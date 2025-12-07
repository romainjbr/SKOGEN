using UnityEngine;
using Skogen.Gameplay.Player;

namespace Skogen.Gameplay.Items.Collectibles
{
    [RequireComponent(typeof(Collider2D))]
    public class CollectibleTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<PlayerController>(out var player)) { return; }

            if (!TryGetComponent<ICollectible>(out var collectible)) { return; }

            collectible.Collect(player);
        }
    }
}