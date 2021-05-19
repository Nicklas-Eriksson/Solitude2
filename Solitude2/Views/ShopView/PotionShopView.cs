using Solitude2.Interfaces;
using Solitude2.Prints;
using Solitude2.Views.PlayerView;
using System;
using System.Collections.Generic;

namespace Solitude2.Views.ShopView
{
    public static class PotionShopView
    {
        /// <summary>
        /// 2 options.
        /// </summary>
        internal static void Buy()
        {
            Console.Clear();
            Logotype.Potions();
            Frame.New(new List<string> { "Potion.", "Main Menu." });
            DrawStatsView.PlayerStats();
        }

        internal static void DisplayInventory(IEnumerable<IItem> potions)
        {
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
