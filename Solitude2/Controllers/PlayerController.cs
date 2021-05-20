using Solitude2.Facade;
using Solitude2.Utility;
using System;
using Solitude2.Controllers.Menu;
using Solitude2.Controllers.System;
using Solitude2.Models;
using Solitude2.Views.Player;
using Solitude2.Views.SetCursorPosition;

namespace Solitude2.Controllers
{
    internal static class PlayerController
    {
        internal static Player CurrentPlayer;

        internal static void CheckIfPlayerIsAlive()
        {
            if (!CurrentPlayer.Alive)
            {
                PlayerView.GameOver();
            }
        }

        internal static void Inventory()
        {
            Console.Clear();
            if (CurrentPlayer.Inventory == null)
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
            if (CurrentPlayer.CurrentLvl >= CurrentPlayer.MaxLvl || !(CurrentPlayer.CurrentExp >= CurrentPlayer.ExpReqForLvl)) return;
            CurrentPlayer.CurrentExp -= CurrentPlayer.ExpReqForLvl;
            CurrentPlayer.CurrentLvl++;
            PlayerView.LevelUp(CurrentPlayer.CurrentLvl);
        }

        internal static void DrinkPotion()
        {
            var typeOfPotion = SelectTypeOfPotion();

            if (CurrentPlayer.Potions.Contains(typeOfPotion) && CurrentPlayer.CurrentHP >= CurrentPlayer.MaxHP) return;
            CurrentPlayer.CurrentHP += typeOfPotion.Bonus;
            if (CurrentPlayer.CurrentHP > CurrentPlayer.MaxHP) { CurrentPlayer.CurrentHP = CurrentPlayer.MaxHP; }
            PlayerView.DrinkPotion(typeOfPotion);
        }

        private static Item SelectTypeOfPotion()
        {
            var input = Helper.GetUserInput(4);
            return CurrentPlayer.Potions[input - 1];
        }
    }
}
