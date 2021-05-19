using Solitude2.Controllers.SystemController;
using Solitude2.Views.PlayerView;

namespace Solitude2.Controllers.PlayerController
{
    internal static class GameOverController
    {
        internal static void GameOver()
        {
            GameOverView.GameOver();
            ExitController.Exit();
        }
    }
}
