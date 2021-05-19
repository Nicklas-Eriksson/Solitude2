using System;
using Solitude2.Controllers.SystemController;
using Solitude2.Models;

namespace Solitude2.Data
{
    internal static class MonsterSeed
    {
        private static readonly MyDbContext db = new();

        internal static bool MonsterForge()
        {
            try
            {
                db.Monsters.AddRange
                (
                    NewMonster("Spider"),
                    NewMonster("Gargoyle"),
                    NewMonster("Zergling"),
                    NewMonster("Banshee"),
                    NewMonster("Ogre"),
                    NewMonster("Hydra"),
                    NewMonster("Hound"),
                    NewMonster("Cultist"),
                    NewMonster("Troll"),
                    NewMonster("Basilisk")
                ); 
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private static Monster NewMonster(string name)
        {
            var playerLvl = StartGameController.CurrentPlayer.CurrentLvl;
            Random rnd = new();
            var lvlMod = rnd.Next(-1, 1);
            var monterLvl = playerLvl + lvlMod;

            return new Monster { AttackName = name, Level = monterLvl, TalentDrop = 1, GoldDrop = monterLvl * 100, ExpDrop = monterLvl * 100, Dmg = monterLvl * 100, Description = "Its a disgusting spider!" };
        }
    }
}
