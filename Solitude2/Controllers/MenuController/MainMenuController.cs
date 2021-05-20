using Solitude2.Controllers.EncounterController;
using Solitude2.Controllers.SystemController;
using Solitude2.Utility;
using Solitude2.Views.MenuView;

namespace Solitude2.Controllers.MenuController
{
    internal static class MainMenuController
    {
        internal static void Options()
        {
            MainMenuView.Home();
            UserOptions(Helper.GetUserInput(5));
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
                    SaveGameController.SaveGame();
                    break;
                case 5:
                    ExitController.Exit();
                    break;
            }
        }
    }
}
