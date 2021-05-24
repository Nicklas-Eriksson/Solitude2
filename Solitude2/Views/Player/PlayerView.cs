using System;
using System.Collections.Generic;
using System.Threading;
using Solitude2.Interfaces;
using Solitude2.Models;
using Solitude2.Prints;

namespace Solitude2.Views.Player
{
    internal static class PlayerView
    {
        internal static void LevelUp(int newLevel)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Level up! Level: {newLevel}");
            Console.ResetColor();
        }

        internal static void GameOver()
        {
            Logotype.GameOver();
            Thread.Sleep(1300);
        }

        internal static void DrinkPotion(Item typeOfPotion)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"You cork up your red glowing bottle and take a big swig..\n {typeOfPotion.Name} grants you +{typeOfPotion.Bonus} health!");
            Console.ResetColor();
        }

        internal static void DisplayPlayerInventory(IEnumerable<IItem> inventory)
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

        internal static void PlayerInventoryIsEmpty()
        {
            Logotype.Inventory();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Inventory is empty!");
            Thread.Sleep(1400);
        }

        public static void AdminPanel()
        {
            Console.WriteLine("All your tables have now been cleared");
            Thread.Sleep(1400);
        }
    }
}
