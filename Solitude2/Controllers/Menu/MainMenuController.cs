using Solitude2.Controllers.Character;
using Solitude2.Controllers.Encounter;
using Solitude2.Controllers.System;
using Solitude2.Utility;
using Solitude2.Views.Menu;

namespace Solitude2.Controllers.Menu
{
    internal static class MainMenuController
    {
        internal static void Options()
        {
            MainMenuView.HomeAdmin();
            if (PlayerController.CurrentPlayer.IsAdmin)
            {
                UserOptionsAdmin(Helper.GetUserInput(6));
            }
            MainMenuView.Home();
            UserOptions(Helper.GetUserInput(5));

        }

        private static void UserOptionsAdmin(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    FightController.NewFight();
                    break;
                case 2:
                    PlayerController.Inventory();
                    break;
                case 3:
                    StoreMenuController.Options();
                    break;
                case 4:
                    SystemControllers.SaveGame();
                    break;
                case 5:
                    SystemControllers.Exit();
                    break;
                case 6:
                    AdminPanelController.AdminPanel();
                    break;
            }
        }

        private static void UserOptions(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    FightController.NewFight();
                    break;
                case 2:
                    PlayerController.Inventory();
                    break;
                case 3:
                    StoreMenuController.Options();
                    break;
                case 4:
                    SystemControllers.SaveGame();
                    break;
                case 5:
                    SystemControllers.Exit();
                    break;
            }
        }
    }
}
