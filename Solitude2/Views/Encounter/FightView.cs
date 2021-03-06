using System;
using System.Collections.Generic;
using System.Threading;
using Solitude2.Interfaces;
using Solitude2.Prints;
using Solitude2.Views.SetCursorPosition;

namespace Solitude2.Views.Encounter
{
    internal static class FightView
    {
        internal static void DmgDealt(float dmgDealt)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{dmgDealt} was dealt!");
            Console.ResetColor();
        }

        internal static void EnemyDrop(float goldDrop, IItem drop)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"(+{goldDrop} gold has been added to your pouch!");
            Console.WriteLine($"({drop.Name} has been added to your inventory!");
            Console.ResetColor();
        }

        internal static void HealthCheck(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{name} has died..");
            Thread.Sleep(1300);
            Console.ResetColor();
        }

        internal static void Flee()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You quickly turn around and run away.");
            Thread.Sleep(1400);
            Console.ResetColor();
        }

        public static void Options()
        {
            Logotype.Encounter();
            DrawMenu.DisplayMenu(new List<string>
           {
               "Attack",
               "Drink Potion",
               "Flee"
           });
        }
    }
}
