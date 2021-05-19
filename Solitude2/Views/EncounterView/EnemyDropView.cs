using Solitude2.Interfaces;
using System;

namespace Solitude2.Views.EncounterView
{
    internal static class EnemyDropView
    {
        internal static void EnemyDrop(float goldDrop, IItem drop)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"(+{goldDrop} gold has been added to your pouch!");
            Console.WriteLine($"({drop.Name} has been added to your inventory!");
            Console.ResetColor();
        }
    }
}
