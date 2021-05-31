using Solitude2.Controllers.System;
using Solitude2.Facade;
using Solitude2.Prints;
using Solitude2.Utility;
using Solitude2.Views.Menu;
using System;
using System.Linq;
using System.Threading;

namespace Solitude2.Controllers.Menu
{
    internal static class AdminPanelController
    {
        internal static void AdminPanel()
        {
            Console.Clear();
            Prints.Logotype.AdminPanel();
            AdminPanelView.DisplayAdminOptions();
            var input = Helper.GetUserInput(3);
            Options(input);
        }

        private static void Options(int input)
        {
            switch (input)
            {
                case 1:
                    EmptyTables();
                    break;
                case 2:
                    DisplayAllPlayers();
                    break;
                case 3:
                    DisplayAllItems();
                    break;
                case 4:
                    GetAllMonsters();
                    break;
                case 5:
                    GetWeaponById();
                    break;
                case 6:
                    BackToMainMenu();
                    break;
                case 7:
                    ExitGame();
                    break;
            }
        }

        private static void EmptyTables()
        {
            Console.Clear();
            Logotype.AdminPanel();
            AdminPanelView.EmptyTables1();
            var success = Helper.SpecificCommand();
            switch (success)
            {
                case 1:
                    SystemControllers.EmptyAllTables();
                    break;
                case 2:
                    break;
                default:
                    AdminPanelView.WrongInput();
                    Thread.Sleep(1300);
                    break;
            }
            AdminPanel();
        }

        private static void DisplayAllPlayers()
        {
            Console.Clear();
            Logotype.AdminPanel(); 
            AdminPanelView.DisplayAllPlayers(DbCommunication.GetPlayers());
            Helper.PressAnyKeyToContinue();
        }

        private static void DisplayAllItems()
        {
            Console.Clear();
            Logotype.AdminPanel();
            AdminPanelView.DisplayAllItems(DbCommunication.GetAllItems());
            Helper.PressAnyKeyToContinue();
        }

        private static void GetAllMonsters()
        {
            Console.Clear();
            Logotype.AdminPanel(); 
            AdminPanelView.DisplayAllMonsters(DbCommunication.GetMonsters());
            Helper.PressAnyKeyToContinue();
        }

        private static void GetWeaponById()
        {
            Console.Clear();
            Logotype.AdminPanel();
            AdminPanelView.GetWeaponById();
            var maxInput = DbCommunication.GetWeapons().Count();
            if (maxInput == 0)
            {
                AdminPanelView.NoWeaponsInDatabase();
                Thread.Sleep(1300);
                AdminPanel();
            }
            var weapon = DbCommunication.GetWeaponsById(Helper.GetUserInput(maxInput));
            AdminPanelView.DisplayWeaponFromId(weapon);
            Helper.PressAnyKeyToContinue();
        }

        private static void BackToMainMenu()
        {
            MainMenuController.Options();
        }

        private static void ExitGame()
        {
            SystemControllers.Exit();
        }
    }
}
