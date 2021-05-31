using Solitude2.Views.SetCursorPosition;
using System;
using System.Collections.Generic;

namespace Solitude2.Views.Menu
{
    public static class StoreMenuView
    {
        public static void IronSkillet()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            DrawMenu.DisplayMenu(new List<string> { "Weapons", "Potions", "Power Ups", "Main Menu" });
        }
    }
}
