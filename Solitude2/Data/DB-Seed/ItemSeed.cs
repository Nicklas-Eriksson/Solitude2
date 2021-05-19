using System;
using Solitude2.Models;

namespace Solitude2.Data
{
    internal static class ItemSeed
    {
        private static readonly MyDbContext db = new();

        internal static bool ItemForge()
        {
            try
            {
                db.Items.AddRange
                (
                    NewItem("Cloth", 100, "Non"),
                    NewItem("Egg", 50, "Some kind of pattern is painted on it."),
                    NewItem("Rabid Squirrel", 200, "Frothy but cute."),
                    NewItem("Chain", 100, "Non"),
                    NewItem("Mushroom", 30, "Red with pretty white dots."),
                    NewItem("Tea Pot", 100, "Non."),
                    NewItem("Rat Tooth", 20, "So small but so sharp."),
                    NewItem("Skillet", 200, "Non sticky.")
                );
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private static Item NewItem(string name, int value, string description )
        {
            return new Item { Name = name, Value = value, Description = description };
        }
    }
}
