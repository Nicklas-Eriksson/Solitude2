using Solitude2.Interfaces;
using System;
using System.Collections.Generic;

namespace Solitude2.Views.Menu
{
    internal static class AdminPanelView
    {
        internal static void EmptyTables1()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Are you sure you want to empty");
            Console.WriteLine("all tables in the database?");
            Console.WriteLine("To go back \nwrite \"Back\" and press \"Enter\":");
            Console.WriteLine("To empty the tables \nwrite the following and press \"Enter\":");
            Console.WriteLine("\"Empty all tables\"");
            Console.ResetColor();
        }

        internal static void WrongInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Wrong input! Try again.");
            Console.ResetColor();
        }

        internal static void DisplayAllPlayers(IEnumerable<Models.Player> players)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var player in players)
            {
                Console.WriteLine($"ID# {player.ID}: {player.Name} LvL: {player.CurrentLvl} Gold: {player.Gold}");
                Console.WriteLine($"Weapon: {player.EquippedWeapon.Name}+{player.EquippedWeapon.Bonus}");
            }
            Console.ResetColor();
        }

        internal static void DisplayAllItems(IEnumerable<IItem> allItems)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var item in allItems)
            {
                Console.WriteLine($"ID# {item.ID}: {item.Name} Value: {item.Value}");
                if (item.IsWeapon)
                {
                    Console.WriteLine($"Weapon damage +{item.Bonus}");
                }
                else if (item.IsPotion)
                {
                    Console.WriteLine($"Healing bonus +{item.Bonus}");
                }
                Console.WriteLine($"Description: {item.Description}");
            }
            Console.ResetColor();
        }

        internal static void DisplayAllMonsters(IEnumerable<IEnemy> monsters)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var enemy in monsters)
            {
                Console.WriteLine($"ID# {enemy.ID}: {enemy.Name}");
                if (enemy.Description != string.Empty)
                {
                    Console.WriteLine($"Description: {enemy.Description}");
                }
            }
            Console.ResetColor();
        }

        internal static void GetWeaponById()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter the Id of the weapon you want to find");
            Console.ResetColor();
        }

        internal static void NoWeaponsInDatabase()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("There are no weapons available");
            Console.ResetColor();
        }
    }
}
