using System;
using Solitude2.Models;

namespace Solitude2.Data
{
    /// <summary>
    /// Weapons for database is seeded here.
    /// </summary>
    internal static class WeaponSeed
    {
        private static readonly MyDbContext Db = new();

        internal static void WeaponForge()
        {
            //Weapon w60 = new() { AttackName = "Thunderfury", Bonus = 600, Value = 6000, Description = "Watch out, its static.", IsWeapon = true, IsPotion = false, IsTrash = false };

            try
            {
                Db.Items.AddRange
                (
                    new Item { Name = "Rusty Dagger", Bonus = 20, Value = 200, Description = "Its short and its rusty.", IsWeapon = true },
                    new Item { Name = "Rubber Mallet", Bonus = 30, Value = 300, Description = "Looks harmless, but hits like a truck.", IsWeapon = true },
                    new Item { Name = "Barbed Baseball Bat", Bonus = 40, Value = 400, Description = "Carved into its surface \"Negan\".", IsWeapon = true },
                    new Item { Name = "Shiny Sword", Bonus = 50, Value = 500, Description = "Looks like its forged from Valyrian steel.", IsWeapon = true },
                    new Item { Name = "Zenith Blade", Bonus = 60, Value = 600, Description = "Strange glowing emits from its surface.", IsWeapon = true },
                    new Item { Name = "Dream Rod", Bonus = 70, Value = 700, Description = "Is that a key?", IsWeapon = true },
                    new Item { Name = "Eviscerator", Bonus = 80, Value = 800, Description = "An obscenely large 2-handed weapon.", IsWeapon = true},
                    new Item { Name = "Avo's Tear", Bonus = 90, Value = 900, Description = "Imbued with extraordinary power.", IsWeapon = true },
                    new Item { Name = "Psionic Blade", Bonus = 100, Value = 1000, Description = "En Taro Tassadar!", IsWeapon = true }
                );
                Db.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}
