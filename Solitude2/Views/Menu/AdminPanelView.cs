using Solitude2.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using Solitude2.Views.SetCursorPosition;

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
            if (allItems == null)
            {
                Console.WriteLine("There are no items in the database at the moment");
                Thread.Sleep(1300);
                return;
            }
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
            if (monsters == null)
            {
                Console.WriteLine("There are no enemies in the database at the moment");
                Thread.Sleep(1300);
                return;
            }
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
            Console.WriteLine("Enter the #ID of the weapon you want to find");
            Console.ResetColor();
        }

        internal static void NoWeaponsInDatabase()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("There are no weapons available");
            Console.ResetColor();
        }

        internal static void DisplayAdminOptions()
        {
            DrawMenu.DisplayMenu(new List<string> { "Empty Tables", "Display All Players", "Display All Items", "Display All Enemies", "Get Weapons by #ID", "Back To Main Menu", "Exit Game" });
        }

        public static void DisplayWeaponFromId(IItem weapon)
        {
            if (weapon == null) { return; }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"#ID: {weapon.ID}");
            Console.WriteLine($"{weapon.Name} +{weapon.Bonus} damage");
            Console.WriteLine($"{weapon.Description}");
            Console.WriteLine($"Item Level: {weapon.ILvl}");
            Console.WriteLine($"Gold Value: {weapon.Value}");
            Console.ResetColor();
        }
    }
}
