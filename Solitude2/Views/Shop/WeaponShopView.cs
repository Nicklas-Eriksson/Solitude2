using Solitude2.Controllers.Character;
using Solitude2.Interfaces;
using Solitude2.Views.SetCursorPosition;
using System;
using System.Collections.Generic;
using Solitude2.Prints;

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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            DisplayInventory(inventory);
            Console.ResetColor();
        }

        private static void DisplayInventory(IEnumerable<IItem> inventory)
        {
            var equippedWepDmg = NullCheckPlayerEquippedWeapon();
            PrintWeapons(inventory, equippedWepDmg);
        }

        private static void PrintWeapons(IEnumerable<IItem> inventory, float equippedWepDmg)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            var index = 1;
            foreach (var item in inventory)
            {
                Console.Write($" {index}: {item.Name} ");

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

                Console.WriteLine();
                Console.ResetColor();
                index++;
            }
        }

        private static float NullCheckPlayerEquippedWeapon()
        {
            float equippedWepDmg;
            if (PlayerController.CurrentPlayer.EquippedWeapon != null)
            {
                equippedWepDmg = MathF.Round(PlayerController.CurrentPlayer.EquippedWeapon.Bonus);
            }
            else
            {
                equippedWepDmg = 0;
            }

            return equippedWepDmg;
        }
    }
}
