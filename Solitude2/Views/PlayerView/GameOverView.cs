using Solitude2.Prints;
using System.Threading;

namespace Solitude2.Views.PlayerView
{
    internal static class GameOverView
    {
        internal static void GameOver()
        {
            Logotype.GameOver();
            Thread.Sleep(1300);
        }
    }
}
