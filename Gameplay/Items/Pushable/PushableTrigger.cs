using Skogen.Gameplay.Player;
using Skogen.Gameplay.Items.Pushable;
using UnityEngine;

namespace Skogen.Gameplay.Items.Pushable
{
    [RequireComponent(typeof(Collider2D))]
    public class PushableTrigger : MonoBehaviour
    {
        private void Reset()
        {
            var col = GetComponent<Collider2D>();
            if (col != null)
            {
                col.isTrigger = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<PlayerController>(out var player)) { return; }

            if (!TryGetComponent<PushableObject>(out var pushable)) { return; }

            player.Context?.Actions?.SetPushable(pushable);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent<PlayerController>(out var player)) { return; }

            if (!TryGetComponent<PushableObject>(out var pushable)) { return; }

            player.Context?.Actions?.ClearPushable(pushable);
        }
    }
}
