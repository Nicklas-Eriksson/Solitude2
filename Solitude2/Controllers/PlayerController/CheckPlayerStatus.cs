using Solitude2.Controllers.SystemController;
using Solitude2.Views.PlayerView;

namespace Solitude2.Controllers.PlayerController
{
    internal static class CheckPlayerStatus
    {
        internal static void Alive()
        {
            if (!StartGameController.CurrentPlayer.Alive)
            {
                GameOverView.GameOver();
            }
        }
    }
}
