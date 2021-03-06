using System;
using Solitude2.Models;

namespace Solitude2.Data
{
    internal static class PotionSeed
    {
        private static readonly MyDbContext Db = new();

        internal static void PotionForge()
        {
            try
            {
                Db.Items.AddRange
                (
                    new Item { Name = "Minor Healing Potion", Bonus = 100, Value = 100, ILvl = 0, IsWeapon = false, IsPotion = true, IsTrash = false},
                    new Item { Name = "Major Healing Potion", Bonus = 200, Value = 200, ILvl = 1, IsWeapon = false, IsPotion = true, IsTrash = false },
                    new Item { Name = "Super Healing Potion", Bonus = 300, Value = 300, ILvl = 2, IsWeapon = false, IsPotion = true, IsTrash = false },
                    new Item { Name = "Ultra Healing Potion", Bonus = 400, Value = 400, ILvl = 3, IsWeapon = false, IsPotion = true, IsTrash = false }
                );
                Db.SaveChanges();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}
