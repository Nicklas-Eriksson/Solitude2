using Solitude2.Interfaces;
using System;
using System.Collections.Generic;

namespace Solitude2.Views.PlayerView
{
    internal static class InventoryView
    {
        internal static void DisplayInventory(IEnumerable<IItem> inventory)
        {
            var index = 1;
            foreach (var item in inventory)
            {
                Console.Write($"{index}: {item.Name} Bonus: {item.Bonus}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Value: {item.Value}");
                Console.ResetColor();
                index++;
            }
        }
    }
}
