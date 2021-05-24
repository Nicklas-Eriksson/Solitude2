using System;
using Solitude2.Models;

namespace Solitude2.Data
{
    internal static class ItemSeed
    {
        private static readonly MyDbContext Db = new();

        internal static void ItemForge()
        {
            try
            {
                Db.Items.AddRange
                (
                    new Item { Name = "Skillet", Value = 200, Description = "Non sticky.", IsTrash = true },
                    new Item { Name = "Cloth", Value = 100, Description = "Rugged linen cloth.", IsTrash = true },
                    new Item { Name = "Egg", Value = 50, Description = "Some kind of pattern is painted on it.", IsTrash = true },
                    new Item { Name = "Rabid Squirrel", Value = 200, Description = "Frothy but cute.", IsTrash = true },
                    new Item { Name = "Tea Pot", Value = 100, Description = "Dusty but in fine condition.", IsTrash = true },
                    new Item { Name = "Mushroom", Value = 200, Description = "Red with pretty white dots.", IsTrash = true },
                    new Item { Name = "Chain", Value = 150, Description = "Gleaming like gold.", IsTrash = true },
                    new Item { Name = "Rat Tooth", Value = 20, Description = "So small but so sharp.", IsTrash = true }
                );
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
