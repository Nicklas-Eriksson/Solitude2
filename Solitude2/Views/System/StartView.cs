using System;
using System.Collections.Generic;
using Solitude2.Prints;
using Solitude2.Views.SetCursorPosition;
using static System.Threading.Thread;

namespace Solitude2.Views.System
{
    internal static class StartView
    {
        /// <summary>
        /// New Game.
        /// Load Game.
        /// Exit Game.
        /// </summary>
        internal static void Game()
        {
            Console.Clear();
            Console.Title = "Solitude 2";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.Welcome();
            Sleep(1300);
            Console.Clear();
            Logotype.Solitude();
            DrawMenu.DisplayMenu(new List<string> { "New Game.", "Load Game.", "Exit Game." });
        }
    }
}