using Solitude2.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using Solitude2.Prints;

namespace Solitude2.Views.PlayerView
{
    internal static class InventoryView
    {
        internal static void DisplayInventory(IEnumerable<IItem> inventory)
        {
            Logotype.Inventory();
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

        internal static void EmptyInventory()
        {
            Logotype.Inventory();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Inventory is empty!");
            Thread.Sleep(1400);
        }
    }
}
