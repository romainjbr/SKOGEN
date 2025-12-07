using UnityEngine;

namespace Skogen.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerContext context;
        public PlayerContext Context => context;

        private void Awake()
        {
            if (context == null) { context = new PlayerContext(this); }
        }

        private void Update()
        {
            Context?.Input?.Tick();
        }
    }
}