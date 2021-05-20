using Solitude2.Facade;
using Solitude2.Utility;
using System;
using Solitude2.Controllers.Menu;
using Solitude2.Controllers.System;
using Solitude2.Views.Player;

namespace Solitude2.Controllers
{
    internal static class PlayerController
    {
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
            PlayerView.GameOver();
            ExitController.Exit();
        }

        public static void CheckPlayerLevel()
        {
            var player = StartGameController.CurrentPlayer;
            if (player.CurrentLvl >= player.MaxLvl || !(player.CurrentExp >= player.ExpReqForLvl)) return;
            player.CurrentExp -= player.ExpReqForLvl;
            player.CurrentLvl++;
            PlayerView.LevelUp(player.CurrentLvl);
        }
    }
}
