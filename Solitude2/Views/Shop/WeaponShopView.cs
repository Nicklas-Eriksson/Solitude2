using System;
using System.Collections.Generic;
using Solitude2.Controllers.SystemController;
using Solitude2.Interfaces;
using Solitude2.Prints;
using Solitude2.Views.Player;

namespace Solitude2.Views.Shop
{
    public static class WeaponShopView
    {
        /// <summary>
        /// 2 options
        /// </summary>
        internal static void DisplayOptions(IEnumerable<IItem> inventory)
        {
            Logotype.Weapons();
            DisplayInventory(inventory);
            DrawStatsView.PlayerStats();
        }

        private static void DisplayInventory(IEnumerable<IItem> inventory)
        {
            var equippedWepDmg = NullCheckPlayerEquippedWeapon();
            PrintWeapons(inventory, equippedWepDmg);
        }

        private static void PrintWeapons(IEnumerable<IItem> inventory, float equippedWepDmg)
        {
            var index = 1;
            foreach (var item in inventory)
            {
                Console.Write($"{index}: {item.Name} ");

                if (equippedWepDmg > MathF.Round(item.Bonus))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"-{item.Bonus}");
                }
                else if (Math.Abs(equippedWepDmg - MathF.Round(item.Bonus)) < 0.1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"{item.Bonus}");
                }
                else if (equippedWepDmg < MathF.Round(item.Bonus))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"+{item.Bonus}");
                }

                Console.ResetColor();
                index++;
            }
        }

        private static float NullCheckPlayerEquippedWeapon()
        {
            float equippedWepDmg;
            if (StartGameController.CurrentPlayer.EquippedWeapon != null)
            {
                equippedWepDmg = MathF.Round(StartGameController.CurrentPlayer.EquippedWeapon.Bonus);
            }
            else
            {
                equippedWepDmg = 0;
            }

            return equippedWepDmg;
        }
    }
}
