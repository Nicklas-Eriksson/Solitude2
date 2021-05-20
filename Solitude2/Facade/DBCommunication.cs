using System;
using Microsoft.EntityFrameworkCore;
using Solitude2.Data;
using Solitude2.Interfaces;
using Solitude2.Models;
using System.Collections.Generic;
using System.Linq;
using Solitude2.Controllers.System;

namespace Solitude2.Facade
{
    internal static class DbCommunication
    {
        private static readonly MyDbContext Db = new();

        internal static List<Player> SavedGames()
        {
            try
            {
                return Db.Players.Include(p => p.Weapons).Include(p => p.Potions).Include(p => p.Inventory).ToList();
            }
            catch (Exception e) { Console.WriteLine(e); }
            return null;
        }

        internal static IEnumerable<IItem> GetPlayerInventory()
        {
            var playerId = StartGameController.CurrentPlayer.ID;

            try
            {
                var player = Db.Players.FirstOrDefault(p => p.ID == playerId);
                if (player != null) return player.Inventory;
            }
            catch (Exception e) { Console.WriteLine(e); }
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
            catch (Exception e) { Console.WriteLine(e); }
            return null;
        }

        internal static IItem GetWeaponsById(int id)
        {
            try
            {
                var weapon = Db.Items.Where(i=>i.IsWeapon == true).FirstOrDefault(w => w.ID == id);
                return weapon ?? null;
            }
            catch (Exception e) { Console.WriteLine(e); }
            return null;
        }

        internal static IEnumerable<IItem> GetPotions()
        {
            try { return Db.Items.Where(i=>i.IsPotion == true).ToList(); }
            catch (Exception e) { Console.WriteLine(e); }
            return null;
        }

        internal static IEnumerable<IItem> GetAllItems()
        {
            try { return Db.Items.ToList(); }
            catch (Exception e) { Console.WriteLine(e); }
            return null;
        }
        internal static IEnumerable<IItem> GetTrashItems()
        {
            try { return Db.Items.Where(i=>i.IsTrash == true).ToList(); }
            catch (Exception e) { Console.WriteLine(e); }
            return null;
        }

        internal static IEnumerable<IEnemy> GetMonsters()
        {
            try { return Db.Monsters.ToList(); }
            catch (Exception e) { Console.WriteLine(e); }
            return null;
        }

        internal static IEnumerable<Player> GetPlayers()
        {
            try { return Db.Players.ToList(); }
            catch (Exception e) { Console.WriteLine(e); }
            return null;
        }
    }
}
