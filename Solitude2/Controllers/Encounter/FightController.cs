using System;
using System.Collections.Generic;
using Solitude2.Controllers.Menu;
using Solitude2.Models;
using Solitude2.Views.EncounterView;
using Solitude2.Views.Player;
using static Solitude2.Controllers.System.StartGameController;

namespace Solitude2.Controllers.Encounter
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

        private static Monster NewMonster()
        {
            var monsterList = (List<Monster>)Facade.DbCommunication.GetMonsters();
            var rndNr = Rnd.Next(0, monsterList.Count);
            return monsterList[rndNr];
        }

        private static void FightingSequence(Monster monster)
        {
            var player = CurrentPlayer;
            var playerDmg = CalculatePlayerDmg(player);
            var round = 0;
            DrawStatsView.DisplayCombatInformation(monster);

            while (monster.Alive)
            {
                if (round % 2 == 0)//Player turn
                {
                    monster.CurrentHp -= playerDmg;
                    FightView.DmgDealt(playerDmg);
                    HealthCheckController.HealthCheck(monster.CurrentHp, monster.Name);
                    round++;
                }
                else//Monster turn
                {
                    player.CurrentHP -= monster.Dmg;
                    FightView.DmgDealt(monster.Dmg);
                    HealthCheckController.HealthCheck(player.CurrentHP, player.Name);
                    PlayerController.CheckIfPlayerIsAlive();
                    round++;
                }
            }

            player.Gold += monster.GoldDrop;
            player.Inventory.Add(monster.Drop);
            player.CurrentExp += monster.ExpDrop;
            EnemyDropView.EnemyDrop(monster.GoldDrop, monster.Drop);
            PlayerController.CheckPlayerLevel();

        }

        private static float CalculatePlayerDmg(Player player)
        {
            var critChance = Rnd.Next(1, (int)CurrentPlayer.CritPercent);
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
