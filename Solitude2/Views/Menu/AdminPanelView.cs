using Solitude2.Interfaces;
using System;
using System.Collections.Generic;

namespace Solitude2.Views.Menu
{
    internal static class AdminPanelView
    {
        internal static void EmptyTables1()
        {
            Console.WriteLine("Are you sure you want to empty");
            Console.WriteLine("all tables in the database?");
            Console.WriteLine("To go back \nwrite \"Back\" and press \"Enter\":");
            Console.WriteLine("To empty the tables \nwrite the following and press \"Enter\":");
            Console.WriteLine("\"Empty all tables\"");
        }

        internal static void WrongInput()
        {
            Console.WriteLine("Wrong input! Try again.");
        }

        internal static void DisplayAllPlayers(IEnumerable<Models.Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"ID# {player.ID}: {player.Name} LvL: {player.CurrentLvl} Gold: {player.Gold}");
                Console.WriteLine($"Weapon: {player.EquippedWeapon.Name}+{player.EquippedWeapon.Bonus}");
            }
        }

        internal static void DisplayAllItems(IEnumerable<IItem> allItems)
        {
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
        }

        internal static void DisplayAllMonsters(IEnumerable<IEnemy> monsters)
        {
            foreach (var enemy in monsters)
            {
                Console.WriteLine($"ID# {enemy.ID}: {enemy.Name}");
                if (enemy.Description != string.Empty)
                {
                    Console.WriteLine($"Description: {enemy.Description}");
                }
            }
        }

        internal static void GetWeaponById()
        {
            Console.WriteLine("Enter the Id of the weapon you want to find.");
        }

        internal static void NoWeaponsInDatabase()
        {
            Console.WriteLine("There are no weapons available.");
        }
    }
}
