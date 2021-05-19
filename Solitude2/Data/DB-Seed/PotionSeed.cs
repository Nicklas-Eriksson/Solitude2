using System;
using Solitude2.Models;

namespace Solitude2.Data
{
    internal static class PotionSeed
    {
        private static readonly MyDbContext Db = new();

        internal static bool PotionForge()
        {
            try
            {
                Db.Potions.AddRange
                (
                    new Potion { Name = "Minor Healing Potion", Bonus = 100, Value = 100},
                    new Potion { Name = "Major Healing Potion", Bonus = 200, Value = 200 },
                    new Potion { Name = "Super Healing Potion", Bonus = 300, Value = 300 },
                    new Potion { Name = "Ultra Healing Potion", Bonus = 400, Value = 400 }
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
