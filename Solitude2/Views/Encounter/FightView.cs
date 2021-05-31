using System;
using System.Threading;
using Solitude2.Interfaces;

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
    }
}
