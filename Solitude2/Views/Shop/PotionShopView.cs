using Solitude2.Interfaces;
using Solitude2.Prints;
using Solitude2.Views.SetCursorPosition;
using System;
using System.Collections.Generic;

namespace Solitude2.Views.Shop
{
    public static class PotionShopView
    {
        /// <summary>
        /// 2 options.
        /// </summary>
        internal static void DisplayPotionMenu()
        {
            Logotype.Potions();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            DrawMenu.DisplayMenu(new List<string>
            {
                "Potion",
                "Main Menu"
            });
            Console.ResetColor();
        }

        internal static void DisplayOptions(IReadOnlyList<IItem> potions)
        {
            if (potions == null) return;
            var index = 1;
            foreach (var potion in potions)
            {
                Console.ResetColor();
                Console.Write($" {index}: {potion.Name} ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"+{potion.Bonus}");
                Console.WriteLine($" Cost:{potion.Value}");
                index++;
            }
        }
    }
}
