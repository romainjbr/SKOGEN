using Skogen.Gameplay.Player.Components;
using Skogen.Gameplay.Player.Stats;
using UnityEngine;

namespace Skogen.Gameplay.Player
{
    [System.Serializable]
    public class PlayerContext
    {
        public PlayerMovement Movement { get; set; }
        public PlayerStats Stats {get; set;}
        public PlayerReferences References { get; set;}

        private PlayerController player;

        public PlayerContext(PlayerController player)
        {
            this.player = player;

            if (Movement == null) { Movement = new PlayerMovement(player); }
            if (Stats == null) { Stats = new PlayerStats(); }
            if (References == null) { References = new PlayerReferences(player); }        
        }
    }
}