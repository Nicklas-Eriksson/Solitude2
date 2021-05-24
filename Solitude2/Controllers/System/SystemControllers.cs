using Solitude2.Controllers.Character;
using Solitude2.Data;
using Solitude2.Facade;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.System;
using System;
using Solitude2.Controllers.Menu;

namespace Solitude2.Controllers.System
{
    internal static class SystemControllers
    {
        internal static void Exit()
        {
            SystemView.ExitGame();
            Environment.Exit(0);
        }

        internal static bool SaveGame()
        {
            SystemView.Save();
            try
            {
                var db = new MyDbContext();
                db.Update(PlayerController.CurrentPlayer);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private static Player Load()
        {
            SystemView.Load();
            var savedGames = DbCommunication.SavedGames();
            SystemView.ChooseACharacter(savedGames);
            if (savedGames == null)
            {
                SystemView.NoSavedGames();
                return null;
            }
            var option = Helper.GetUserInput(savedGames.Count);
            if (option == 999) { CurrentGame(); }
            return savedGames[option - 1];
        }

        internal static void EmptyAllTables()
        {
            using MyDbContext db = new();
            db.Items.Clear();
            db.Monsters.Clear();
            db.Players.Clear();
        }

        internal static void CurrentGame()
        {
            var tableIsFull = DbCommunication.CheckForEmptySeedTables();
            if (!tableIsFull) { Data.RunAllSeeds.CreateItems(); }
            SystemView.StartGame();
            PlayerController.CurrentPlayer = UserOptions(Helper.GetUserInput(3));
            MainMenuController.Options();
        }

        /// <summary>
        /// Lets the user either load a previous game, start a new game, or exit the
        /// application.
        /// 1 > New Game.
        /// 2 > Load Game.
        /// 3 > Exit Game.
        /// </summary>
        /// <param name="userInput">Option user chooses.</param>
        /// <returns></returns>
        private static Player UserOptions(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    var player = NewGameController.NewGame();
                    if (player == null) { CurrentGame(); }
                    return player;
                case 2:
                    player = SystemControllers.Load();
                    if (player == null) { NewGameController.NewGame(); }
                    return player;
                case 3:
                    SystemControllers.Exit();
                    return null;
                default:
                    return null;
            }
        }
    }
}
