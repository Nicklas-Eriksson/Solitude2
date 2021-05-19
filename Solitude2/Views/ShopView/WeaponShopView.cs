﻿using Solitude2.Controllers.SystemController;
using Solitude2.Interfaces;
using Solitude2.Prints;
using System;
using System.Collections.Generic;
using Solitude2.Views.PlayerView;

namespace Solitude2.Views.ShopView
{
    public class WeaponShopView
    {
        /// <summary>
        /// 2 options
        /// </summary>
        internal static void DisplayOptions(IEnumerable<IItem> inventory)
        {
            Console.Clear();
            Logotype.Weapons();
            DisplayInventory(inventory);
            DrawStatsView.PlayerStats();
        }

        internal static void DisplayInventory(IEnumerable<IItem> inventory)
        {
            float equippedWepDmg;
            if (StartGameController.CurrentPlayer.EquippedWeapon != null)
            {
                equippedWepDmg = MathF.Round(StartGameController.CurrentPlayer.EquippedWeapon.Bonus);
            }
            else { equippedWepDmg = 0; }

            var index = 1;
            foreach (var item in inventory)
            {
                Console.Write($"{index}: {item.Name} ");

                if (equippedWepDmg > MathF.Round(item.Bonus))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"-{item.Bonus}");
                }
                else if (equippedWepDmg == MathF.Round(item.Bonus))
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
    }
}
