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

        private static void FightOptions(Monster monster)
        {
            //attack
            //pot
            //flee

            var userInput = Helper.GetUserInput(3);
            switch (userInput)
            {
                case 1:
                    FightingSequence(monster);
                    break;
                case 2:
                    PlayerController.DrinkPotion();
                    break;
                case 3:
                    break;
            }
        }

        internal static void NewFight()
        {
            FightOptions(NewMonster());
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
            var playerDmg = CalculatePlayerDmg(CurrentPlayer);
            var round = 0;
            DrawStatsView.DisplayCombatInformation(monster);

            while (monster.Alive)
            {
                if (round % 2 == 0)//Player turn
                {
                    monster.CurrentHp -= playerDmg;
                    FightView.DmgDealt(playerDmg);
                    var result = HealthCheck(monster.CurrentHp, monster.Name);
                    if (!result) { monster.Alive = false;}
                    round++;
                }
                else//Monster turn
                {
                    CurrentPlayer.CurrentHP -= monster.Dmg;
                    FightView.DmgDealt(monster.Dmg);
                    HealthCheck(CurrentPlayer.CurrentHP, CurrentPlayer.Name);
                    PlayerController.CheckIfPlayerIsAlive();
                    round++;
                }
            }

            CurrentPlayer.Gold += monster.GoldDrop;
            CurrentPlayer.Inventory.Add(monster.Drop);
            CurrentPlayer.CurrentExp += monster.ExpDrop;
            FightView.EnemyDrop(monster.GoldDrop, monster.Drop);
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

        private static bool HealthCheck(float hp, string name)
        {
            if (hp > 0) { return true; }
            if (name == PlayerController.CurrentPlayer.Name)
            {
                PlayerController.GameOver();
            }
            FightView.HealthCheck(name);
            return false; }
    }
}
