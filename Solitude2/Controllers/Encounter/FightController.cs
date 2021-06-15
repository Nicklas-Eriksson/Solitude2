using Solitude2.Controllers.Character;
using Solitude2.Controllers.Menu;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.Encounter;
using Solitude2.Views.SetCursorPosition;
using System;
using System.Collections.Generic;
using static Solitude2.Controllers.Character.PlayerController;

namespace Solitude2.Controllers.Encounter
{
    internal static class FightController
    {
        private static readonly Random Rnd = new();
        private static float PlayerDmg { get; set; }
        private static Monster Enemy { get; set; }
        private static int _round = default;

        internal static void NewFight()
        {
            FightView.Options();
            Enemy = NewMonster();
            while (Enemy.Alive)
            {
                FightOptions();
            }
            MainMenuController.Options();
        }

        private static void FightOptions()
        {
            var userInput = Helper.GetUserInput(3);
            switch (userInput)
            {
                case 1:
                    Attack();
                    break;
                case 2:
                    PlayerController.DrinkPotion();
                    break;
                case 3:
                    FightView.Flee();
                    break;
            }
        }

        private static Monster NewMonster()
        {
            var monsterList = (List<Monster>)Facade.DbCommunication.GetMonsters();
            var rndNr = Rnd.Next(0, monsterList.Count);
            var selectedEnemy = monsterList[rndNr];

            var rndBonusLevel = Rnd.Next(-1, 1);
            selectedEnemy.Level = CurrentPlayer.CurrentLvl + rndBonusLevel;
            selectedEnemy.CurrentHp = selectedEnemy.MaxHp;
            return selectedEnemy;
        }

        private static void Attack()
        {
            DrawStatsView.DisplayCombatInformation(Enemy);
            PlayerDmg = CalculatePlayerDmg(CurrentPlayer);

            if (Enemy.Alive)
            {
                if (_round % 2 == 0)//Player turn
                {
                    Enemy.CurrentHp -= PlayerDmg;
                    FightView.DmgDealt(PlayerDmg);
                    var result = HealthCheck(Enemy.CurrentHp, Enemy.Name);
                    if (!result) { Enemy.Alive = false; }
                    _round++;
                }
                else//Monster turn
                {
                    CurrentPlayer.CurrentHP -= Enemy.Dmg;
                    FightView.DmgDealt(Enemy.Dmg);
                    HealthCheck(CurrentPlayer.CurrentHP, CurrentPlayer.Name);
                    PlayerController.CheckIfPlayerIsAlive();
                    _round++;
                }
            }

            if (Enemy.Alive) return;
            CurrentPlayer.Gold += Enemy.GoldDrop;
            CurrentPlayer.Inventory.Add(Enemy.Drop);
            CurrentPlayer.CurrentExp += Enemy.ExpDrop;
            FightView.EnemyDrop(Enemy.GoldDrop, Enemy.Drop);
            PlayerController.CheckPlayerLevel();
        }

        private static float CalculatePlayerDmg(Player player)
        {
            var critChance = Rnd.Next(1, (int)CurrentPlayer.CriticalPercent);
            float playerDmg;
            if (critChance == 1) //Critical hit
            {
                playerDmg =
                    player.AttackPower +
                    player.EquippedWeapon.Bonus +
                    CurrentPlayer.CriticalBonus;
            }
            else
            {
                playerDmg =
                    player.AttackPower +
                    player.EquippedWeapon.Bonus;
            }

            return playerDmg;
        }

        private static bool HealthCheck(float hp, string name)
        {
            if (hp > 0) { return true; }
            if (name == PlayerController.CurrentPlayer.Name)
            {
                PlayerController.GameOver();
            }
            FightView.HealthCheck(name);
            return false;
        }
    }
}
