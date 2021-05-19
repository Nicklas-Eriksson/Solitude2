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
        internal static Weapon Fists = new() { Name = "Fists", Bonus = 1, Value = 0, Description = "Scrawny little hands" };

        internal static bool WeaponForge()
        {
            //Weapon w60 = new() { AttackName = "Thunderfury", Bonus = 600, Value = 6000, Description = "Watch out, its static." };

            try
            {
                Db.Weapons.AddRange
                (
                    new Weapon { Name = "Rusty Dagger", Bonus = 20, Value = 200, Description = "Its short and its rusty." },
                    new Weapon { Name = "Rubber Mallet", Bonus = 30, Value = 300, Description = "Looks harmless, but hits like a truck." },
                    new Weapon { Name = "Barbed Baseball Bat", Bonus = 40, Value = 400, Description = "Carved into its surface \"Negan\"." },
                    new Weapon { Name = "Shiny Sword", Bonus = 50, Value = 500, Description = "Looks like its forged from Valyrian steel." },
                    new Weapon { Name = "Zenith Blade", Bonus = 60, Value = 600, Description = "Strange glowing emits from its surface." },
                    new Weapon { Name = "Dream Rod", Bonus = 70, Value = 700, Description = "Is that a key?" },
                    new Weapon { Name = "Eviscerator", Bonus = 80, Value = 800, Description = "An obscenely large 2-handed weapon." },
                    new Weapon { Name = "Avo's Tear", Bonus = 90, Value = 900, Description = "Imbued with extraordinary power." },
                    new Weapon { Name = "Psionic Blade", Bonus = 100, Value = 1000, Description = "En Taro Tassadar!" }
                );
                Db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
