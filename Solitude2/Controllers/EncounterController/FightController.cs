using System;
using System.Collections.Generic;
using Solitude2.Controllers.MenuController;
using Solitude2.Controllers.PlayerController;
using Solitude2.Models;
using Solitude2.Views.EncounterView;
using static Solitude2.Controllers.SystemController.StartGameController;

namespace Solitude2.Controllers.EncounterController
{
    internal static class FightController
    {
        private static readonly Random Rnd = new();

        internal static void NewFight()
        {
            var monster = NewMonster();
            FightingSequence(monster);
            MainMenuController.Options();
        }

        internal static Monster NewMonster()
        {
            var monsterList = (List<Monster>)Facade.DbCommunication.GetMonsters();
            var rndNr = Rnd.Next(0, monsterList.Count);
            return monsterList[rndNr];
        }

        internal static void FightingSequence(Monster monster)
        {
            var player = CurrentPlayer;
            var playerDmg = CalculatePlayerDmg(player);
            var round = 0;

            while (monster.Alive || player.Alive)
            {
                if (round % 2 == 0)//Player turn
                {
                    monster.CurrentHP -= playerDmg;
                    FightView.DmgDealt(playerDmg);
                    HealthCheckController.HealthCheck(monster.CurrentHP, monster.Name);
                    round++;
                }
                else//Monster turn
                {
                    player.CurrentHP -= monster.Dmg;
                    FightView.DmgDealt(monster.Dmg);
                    HealthCheckController.HealthCheck(player.CurrentHP, player.Name);
                    CheckPlayerStatus.Alive();
                    round++;
                }
            }

            if (!monster.Alive)
            {
                player.Gold += monster.GoldDrop;
                player.Inventory.Add(monster.Drop);
                EnemyDropView.EnemyDrop(monster.GoldDrop, monster.Drop);
            }
        }

        private static float CalculatePlayerDmg(Player player)
        {
            var critChance = Rnd.Next(1, (int) CurrentPlayer.CritPercent);
            float playerDmg;
            if (critChance == 1) //Critical hit
            {
                playerDmg =
                    player.AttackPower +
                    player.EquippedWeapon.Bonus +
                    CurrentPlayer.CritBonus;
            }
            else
            {
                playerDmg =
                    player.AttackPower +
                    player.EquippedWeapon.Bonus;
            }

            return playerDmg;
        }
    }
}
