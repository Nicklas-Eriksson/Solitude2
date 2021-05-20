using System;
using System.Threading;
using Solitude2.Prints;

namespace Solitude2.Views.Player
{
    internal static class PlayerView
    {
        internal static void LevelUp(int newLevel)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Level up! Level: {newLevel}");
            Console.ResetColor();
        }

        internal static void GameOver()
        {
            Logotype.GameOver();
            Thread.Sleep(1300);
        }
    }
}
