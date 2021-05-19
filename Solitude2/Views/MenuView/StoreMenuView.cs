using System;
using System.Collections.Generic;
using Solitude2.Prints;

namespace Solitude2.Views.MenuView
{
    public class StoreMenuView
    {
        public static void IronSkillet()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.IronSkillet();
            Frame.New(new List<string> { "Weapons.", "Power Ups.", "Potions.", "Main Menu."});
        }
    }
}
