using Microsoft.EntityFrameworkCore;
using Solitude2.Controllers.Character;
using Solitude2.Data;
using Solitude2.Interfaces;
using Solitude2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitude2.Facade
{
    internal static class DbCommunication
    {
        private static readonly MyDbContext Db = new();

        internal static List<Player> SavedGames()
        {
            try
            {
                return Db.Players.Include(p => p.Inventory).ToList();
            }
            catch { Console.WriteLine("Saved games = 0"); }
            return null;
        }

        internal static IEnumerable<IItem> GetPlayerInventory()
        {
            try
            {
                var player = Db.Players.FirstOrDefault(p => p.ID == PlayerController.CurrentPlayer.ID);
                if (player != null) return player.Inventory;
            }
            catch { Console.WriteLine("Player inventory = 0"); }
            return null;
        }

        internal static bool CheckForEmptySeedTables()
        {
            try
            {
                var items = Db.Items.ToList();
                if (items.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            return false;
        }

        internal static IEnumerable<IItem> GetWeapons()
        {
            try { return Db.Items.ToList(); }
            catch { Console.WriteLine("Weapons = 0"); }
            return null;
        }

        internal static IItem GetWeaponsById(int id)
        {
            try
            {
                var weapon = Db.Items.Where(i => i.IsWeapon == true).FirstOrDefault(w => w.ID == id);
                return weapon ?? null;
            }
            catch (Exception e) { Console.WriteLine(e); }
            return null;
        }

        internal static IEnumerable<IItem> GetPotions()
        {
            try { return Db.Items.Where(i => i.IsPotion == true).ToList(); }
            catch { Console.WriteLine("Potions = 0"); }
            return null;
        }

        internal static IEnumerable<IItem> GetAllItems()
        {
            try { return Db.Items.ToList(); }
            catch { Console.WriteLine("Items = 0"); }
            return null;
        }

        internal static IEnumerable<IItem> GetTrashItems()
        {
            try { return Db.Items.Where(i => i.IsTrash == true).ToList(); }
            catch { Console.WriteLine("Items = 0"); }
            return null;
        }

        internal static IEnumerable<IEnemy> GetMonsters()
        {
            try { return Db.Monsters.ToList(); }
            catch { Console.WriteLine("Monsters = 0"); }
            return null;
        }

        internal static IEnumerable<Player> GetPlayers()
        {
            try { return Db.Players.ToList(); }
            catch { Console.WriteLine("Players = 0"); }
            return null;
        }
    }
}
