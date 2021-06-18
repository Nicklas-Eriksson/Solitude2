using System;
using System.Collections.Generic;
using Solitude2.Prints;
using Solitude2.Views.SetCursorPosition;

namespace Solitude2.Views.Menu
{
    public static class MainMenuView
    {
        /// <summary>
        /// 5 options.
        /// Explore.
        /// Inventory.
        /// Store.
        /// Save Game.
        /// Exit Game.
        /// </summary>
        public static void Home()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.MainMenu();
            DrawMenu.DisplayMenu(new List<string>
            {
                "Explore",
                "Inventory",
                "Store",
                "Save Game",
                "Log Out",
                "Exit Game"
            });
        }

        public static void HomeAdmin()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.MainMenu();
            DrawMenu.DisplayMenu(new List<string>
            {
                "Explore",
                "Inventory",
                "Store",
                "Save Game",
                "Admin Panel",
                "Log Out",
                "Exit Game"
            });
        }
    }
}
