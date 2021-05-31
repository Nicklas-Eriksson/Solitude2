using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Solitude2.Controllers.Character;
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
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Logotype.GameOver();
            Thread.Sleep(1300);
        }

        internal static void DrinkPotion(Item typeOfPotion)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"You cork up your red glowing bottle and take a big swig..\n {typeOfPotion.Name} grants you +{typeOfPotion.Bonus} health!");
            Console.ResetColor();
        }

        internal static void DisplayPlayerInventory(List<IItem> inventory)
        {
            Console.ResetColor();
            DisplayPotions(inventory);
            DisplayWeapons(inventory);
            DisplayThrashItems(inventory);
        }

        private static void DisplayThrashItems(List<IItem> inventory)
        {
            var index = 1;
            Console.WriteLine("Items:");
            foreach (var item in inventory.Where(i => i.IsTrash))
            {
                Console.Write($"{index}: {item.Name}");
                Console.WriteLine($"Description: {item.Description}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Value: {item.Value}");
                Console.ResetColor();
                index++;
            }
        }

        private static void DisplayWeapons(List<IItem> inventory)
        {
            var playerWeapon = PlayerController.CurrentPlayer.EquippedWeapon;
            var index = 1;
            Console.WriteLine("Weapons:");
            foreach (var weapon in inventory.Where(i => i.IsWeapon))
            {
                CompareWeaponDamage(playerWeapon, weapon, index);
                Console.WriteLine($"Description: {weapon.Description}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Value: {weapon.Value}");
                Console.ResetColor();
                index++;
            }
        }

        private static void DisplayPotions(List<IItem> inventory)
        {
            var index = 1;
            Console.WriteLine("Potions:");
            foreach (var potion in inventory.Where(i => i.IsPotion))
            {
                Console.Write($"{index}: {potion.Name} Healing: +{potion.Bonus}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Value: {potion.Value}");
                Console.ResetColor();
                index++;
            }
        }

        private static void CompareWeaponDamage(Item playerWeapon, IItem weapon, int index)
        {
            var weaponDmgDiff = playerWeapon.Bonus - weapon.Bonus;
            Console.Write($"{index}: {weapon.Name} ");
            if (weapon.Bonus < playerWeapon.Bonus)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Damage: {weaponDmgDiff}");
            }
            else if (Math.Abs(weapon.Bonus - playerWeapon.Bonus) < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Damage: {weaponDmgDiff}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Damage: +{weaponDmgDiff}");
            }
        }

        internal static void PlayerInventoryIsEmpty()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Inventory is empty!");
            Thread.Sleep(1400);
        }

        internal static void TablesAreCleared()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("All your tables have now been cleared");
            Thread.Sleep(1400);
            Console.ResetColor();
        }
    }
}
