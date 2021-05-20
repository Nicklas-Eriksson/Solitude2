using Solitude2.Controllers.MenuController;
using Solitude2.Facade;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.System;

namespace Solitude2.Controllers.SystemController
{
    public static class StartGameController
    {
        internal static Player CurrentPlayer = new();

        public static void CurrentGame()
        {
            var tableIsFull = DbCommunication.CheckForEmptySeedTables();
            if (!tableIsFull) { Data.RunAllSeeds.CreateItems(); }
            StartView.Game();
            CurrentPlayer = UserOptions(Helper.GetUserInput(3));
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
                    var player = NewGameController.CharacterCreation();
                    if (player == null) { CurrentGame(); }
                    return player;
                case 2:
                    player = LoadGameController.Load();
                    if (player == null) { NewGameController.CharacterCreation(); }
                    return player;
                case 3:
                    ExitController.Exit();
                    return null;
                default:
                    return null;
            }
        }
    }
}