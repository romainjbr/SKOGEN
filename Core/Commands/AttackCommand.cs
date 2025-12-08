using Skogen.Gameplay.Player;

namespace Skogen.Core.Commands
{
    public class AttackCommand : Command
    {
        private readonly PlayerController player;

        public AttackCommand(PlayerController player)
        {
            this.player = player;
        }

        public override void Execute()
        {
            player?.Context?.Combat?.Attack();
        }
    }
}