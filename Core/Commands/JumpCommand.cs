using Skogen.Gameplay.Player;

namespace Skogen.Core.Commands
{
    public class JumpCommand : Command
    {
        private readonly PlayerController player;

        public JumpCommand(PlayerController player)
        {
            this.player = player;
        }

        public override void Execute()
        {
            player?.Context?.Movement?.Jump();
        }
    }
}
