using Solitude2.Facade;
using Solitude2.Utility;
using System;
using Solitude2.Controllers.Menu;
using Solitude2.Controllers.System;
using Solitude2.Models;
using Solitude2.Views.Player;

namespace Solitude2.Controllers
{
    internal static class PlayerController
    {
        internal static Player Player= StartGameController.CurrentPlayer;

        internal static void CheckIfPlayerIsAlive()
        {
            if (!StartGameController.CurrentPlayer.Alive)
            {
                PlayerView.GameOver();
            }
        }

        internal static void Inventory()
        {
            Console.Clear();
            if (Player.Inventory == null)
            {
                InventoryView.EmptyInventory();
            }
            else
            {
                InventoryView.DisplayInventory(DbCommunication.GetPlayerInventory());
            }
            DrawStatsView.PlayerStats();
            Helper.PressAnyKeyToContinue();
            MainMenuController.Options();
        }

        internal static void GameOver()
        {
            Console.Clear();
            PlayerView.GameOver();
            ExitController.Exit();
        }

        internal static void CheckPlayerLevel()
        {
            if (Player.CurrentLvl >= Player.MaxLvl || !(Player.CurrentExp >= Player.ExpReqForLvl)) return;
            Player.CurrentExp -= Player.ExpReqForLvl;
            Player.CurrentLvl++;
            PlayerView.LevelUp(Player.CurrentLvl);
        }

        internal static void DrinkPotion()
        {
            var typeOfPotion = SelectTypeOfPotion();

            if (Player.Potions.Contains(typeOfPotion) && Player.CurrentHP >= Player.MaxHP) return;
            Player.CurrentHP += typeOfPotion.Bonus;
            if (Player.CurrentHP > Player.MaxHP) { Player.CurrentHP = Player.MaxHP; }
            PlayerView.DrinkPotion(typeOfPotion);
        }

        private static Item SelectTypeOfPotion()
        {
            var input = Helper.GetUserInput(4);
            return Player.Potions[input - 1];
        }
    }
}
