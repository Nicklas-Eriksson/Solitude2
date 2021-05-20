using System;
using System.Collections.Generic;
using Solitude2.Prints;
using Solitude2.Views.SetCursorPosition;

namespace Solitude2.Views.MenuView
{
    public static class StoreMenuView
    {
        public static void IronSkillet()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.IronSkillet();
            DrawMenu.DisplayMenu(new List<string> { "Weapons.", "Power Ups.", "Potions.", "Main Menu."});
        }
    }
}
