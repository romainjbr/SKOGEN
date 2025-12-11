using Skogen.Gameplay.Player.Components;
using Skogen.Gameplay.Player.Data;
using UnityEngine;

namespace Skogen.Gameplay.Player
{
    [System.Serializable]
    public class PlayerContext
    {
        public PlayerMovement Movement { get; set; }
        public PlayerStats Stats {get; set;}
        public PlayerReferences References { get; set;}
        public PlayerInput Input { get; set;}
        public PlayerInventory Inventory { get; set; }
        public PlayerHealth Health { get; set; }
        public PlayerCombat Combat { get; set; }

        public PlayerActions Actions { get; set; }

        private PlayerController player;

        public PlayerContext(PlayerController player)
        {
            this.player = player;

            if (Movement == null) { Movement = new PlayerMovement(player); }
            if (Stats == null) { Stats = new PlayerStats(); }
            if (References == null) { References = new PlayerReferences(player); }    
            if (Input == null) { Input = new PlayerInput(player); }        
            if (Inventory == null) { Inventory = new PlayerInventory(); }  
            if (Health == null) { Health = new PlayerHealth(player); }  
            if (Combat == null) { Combat = new PlayerCombat(player); }  
            if (Actions == null) { Actions = new PlayerActions(player); }  
        }
    }
}