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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            DrawMenu.DisplayMenu(new List<string> { "Potion", "Main Menu" });
            DrawStatsView.PlayerStats();
            Console.ResetColor();
        }

        internal static void DisplayOptions(IReadOnlyList<IItem> potions)
        {
            if (potions == null) return;
            var index = 1;
            foreach (var potion in potions)
            {
                Console.ResetColor();
                Console.Write($"{index}: {potion.Name} Healing: {potion.Bonus}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($" Cost:{potion.Value}");
                index++;
            }
        }
    }
}
