using Skogen.Gameplay.Player;
using UnityEngine;

namespace Skogen.Gameplay.Items.Collectibles
{
    public class KannelbullaCollectible : MonoBehaviour, ICollectible
    {
        [SerializeField] private int healAmount = 1;

        public void Collect(PlayerController player)
        {
        }
    }
}