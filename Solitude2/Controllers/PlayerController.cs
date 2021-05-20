using Solitude2.Controllers.MenuController;
using Solitude2.Controllers.SystemController;
using Solitude2.Facade;
using Solitude2.Utility;
using Solitude2.Views.PlayerView;
using System;

namespace Solitude2.Controllers
{
    internal static class PlayerController
    {
        internal static void CheckIfPlayerIsAlive()
        {
            if (!StartGameController.CurrentPlayer.Alive)
            {
                GameOverView.GameOver();
            }
        }

        internal static void Inventory()
        {
            Console.Clear();
            if (StartGameController.CurrentPlayer.Inventory == null)
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
            GameOverView.GameOver();
            ExitController.Exit();
        }

        public static void CheckPlayerLevel()
        {
            throw new NotImplementedException();
        }
    }
}
