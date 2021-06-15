using Solitude2.Controllers.Character;
using Solitude2.Models;
using System;

namespace Solitude2.Data
{
    internal static class MonsterSeed
    {
        private static readonly MyDbContext Db = new();

        internal static bool MonsterForge()
        {
            try
            {
                Db.Monsters.AddRange
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
                Db.SaveChanges();
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
            var playerLvl = PlayerController.CurrentPlayer.CurrentLvl;
            Random rnd = new();
            var lvlMod = rnd.Next(-1, 1);
            var monsterLvl = playerLvl + lvlMod;
            return new Monster { Name = name, Level = monsterLvl, Description = "Its a disgusting spider!" };
        }
    }
}
