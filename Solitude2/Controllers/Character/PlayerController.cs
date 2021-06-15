using Solitude2.Controllers.Menu;
using Solitude2.Controllers.System;
using Solitude2.Facade;
using Solitude2.Models;
using Solitude2.Prints;
using Solitude2.Utility;
using Solitude2.Views.Player;
using Solitude2.Views.SetCursorPosition;
using System;
using System.Linq;

namespace Solitude2.Controllers.Character
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
            Logotype.Inventory();
            if (CurrentPlayer.Inventory == null)
            {
                PlayerView.PlayerInventoryIsEmpty();
            }
            else
            {
                PlayerView.DisplayPlayerInventory(DbCommunication.GetPlayerInventory().ToList());
            }
            DrawStatsView.PlayerStats();
            Helper.PressEnterToContinue();
            MainMenuController.Options();
        }

        internal static void GameOver()
        {
            Console.Clear();
            PlayerView.GameOver();
            SystemControllers.Exit();
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
            var player = CurrentPlayer;
            var typeOfPotion = SelectTypeOfPotion(player);

            if (typeOfPotion == null || player.CurrentHP >= player.MaxHP ) return;
            player.CurrentHP += typeOfPotion.Bonus;
            if (player.CurrentHP > player.MaxHP) { player.CurrentHP = player.MaxHP; }
            PlayerView.DrinkPotion(typeOfPotion);
        }

        //REFACTOR TO VIEW
        private static Item SelectTypeOfPotion(Player player)
        {
            if (player.Inventory.Where(i=>i.IsPotion).Count() > 0) return null;
            var potionListFromDatabase = DbCommunication.GetPotions().ToList();
            Console.WriteLine("Drink potion:");
            foreach (var potion in player.Inventory.Where(i=>i.IsPotion))
            {
                foreach (var dBPot in potionListFromDatabase)
                {
                    if (dBPot.Name == potion.Name)
                    {
                        Console.WriteLine(
                            $"{potion.Name} {player.Inventory.Where(i => i.IsPotion).Where(p => p.Name == potion.Name).Count()} ");
                    };
                }
            }

            var input = Helper.GetUserInput(4);
            return CurrentPlayer.Inventory[input - 1];
        }
    }
}
