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
                var items = DbCommunication.GetPlayerInventory().ToList();
                var weapons = items.Where(i => i.IsWeapon).ToList();
                var potions = items.Where(i => i.IsPotion).ToList();
                var thrash = items.Where(i => i.IsTrash).ToList();
                PlayerView.DisplayPlayerInventory(weapons,potions,thrash);
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

        internal static void CheckForLevelUp()
        {
            if (CurrentPlayer.CurrentLvl >= CurrentPlayer.MaxLvl || !(CurrentPlayer.CurrentExp >= CurrentPlayer.ExpReqForLvl)) return;
            CurrentPlayer.CurrentExp -= CurrentPlayer.ExpReqForLvl;
            CurrentPlayer.CurrentLvl++;
            CurrentPlayer.MaxHP += 50;
            CurrentPlayer.AttackPower += 20;
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
                foreach (var dBPot in potionListFromDatabase.Where(dBPot => dBPot.Name == potion.Name))
                {
                    Console.WriteLine($"{potion.Name} {player.Inventory.Where(i => i.IsPotion).Where(p => p.Name == potion.Name).Count()}");
                }
            }

            var input = Helper.GetUserInput(4);
            return (Item)CurrentPlayer.Inventory[input - 1];
        }
    }
}
