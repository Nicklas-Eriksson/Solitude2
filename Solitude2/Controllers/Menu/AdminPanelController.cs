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
            Logotype.AdminPanel();
            AdminPanelView.DisplayAdminOptions();
            var input = Helper.GetUserInput(8);
            Options(input);
        }

        private static void Options(int input)
        {
            switch (input)
            {
                case 1:
                    EmptyTables(); // OK
                    break;
                case 2:
                    DisplayAllPlayers(); // OK
                    break;
                case 3:
                    GetPlayerByName(); // OK
                    break;
                case 4:
                    DisplayAllItems(); // OK
                    break;
                case 5:
                    GetAllMonsters();
                    break;
                case 6:
                    GetWeaponById();
                    break;
                case 7:
                    BackToMainMenu();
                    break;
                case 8:
                    ExitGame();
                    break;
            }
        }

        private static void GetPlayerByName()
        {
            Console.Clear();
            Logotype.AdminPanel();
            AdminPanelView.PromptUserForNameInput();
            AdminPanelView.DisplayCharacterByName(DbCommunication.GetPlayerByName(Console.ReadLine()?.Trim()));
            Helper.PressEnterToContinue();
        }

        private static void EmptyTables()
        {
            Console.Clear();
            Logotype.AdminPanel();
            AdminPanelView.EmptyTables1();
            Helper.PromptUserForStringInput();
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
            Helper.PressEnterToContinue();
        }

        private static void DisplayAllItems()
        {
            Console.Clear();
            Logotype.AdminPanel();
            AdminPanelView.DisplayAllItems(DbCommunication.GetAllItems());
            Helper.PressEnterToContinue();
        }

        private static void GetAllMonsters()
        {
            Console.Clear();
            Logotype.AdminPanel();
            AdminPanelView.DisplayAllMonsters(DbCommunication.GetMonsters());
            Helper.PressEnterToContinue();
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
            Helper.PressEnterToContinue();
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
