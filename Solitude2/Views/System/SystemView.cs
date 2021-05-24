using Solitude2.Prints;
using Solitude2.Views.SetCursorPosition;
using System;
using System.Collections.Generic;
using static System.Threading.Thread;

namespace Solitude2.Views.System
{
    internal static class SystemView
    {
        /// <summary>
        /// New Game.
        /// Load Game.
        /// Exit Game.
        /// </summary>
        internal static void StartGame()
        {
            Console.Clear();
            Console.Title = "Solitude 2";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.Welcome();
            Sleep(1300);
            Console.Clear();
            Logotype.Solitude();
            DrawMenu.DisplayMenu(new List<string> { "New Game.", "Load Game.", "Exit Game." });
        }

        internal static void Save()
        {
            Console.Clear();
            Logotype.Save();
        }

        internal static void ExitGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.Exit();
            Console.WriteLine("Exiting application.");
            Sleep(2000);
        }

        /// <summary>
        /// Prompts user to load a previous game.
        /// </summary>
        internal static void Load()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.LoadGame();
            DrawMenu.DisplayMenuNoNumbers(new List<string>
            {
                "Load a previous game from the list below.",
                "To go back press \"B\" and press \"Enter\"."
            });
        }

        internal static void NoSavedGames()
        {
            Console.WriteLine("There are no previous games to load..");
            Sleep(1000);
            Console.WriteLine("Try creating a new character!");
            Sleep(1000);
        }


        internal static void ChooseACharacter(IEnumerable<Models.Player> players)
        {
            Console.WriteLine("Here are all the saved games:\n");
            var index = 1;
            foreach (var player in players)
            {
                Console.WriteLine($"{index}: {player.Name} Level: {player.CurrentLvl} Gold: {player.Gold}");
                index++;
            }
        }

        /// <summary>
        /// Prompt to create a new game.
        /// </summary>
        internal static void New()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.NewGame();
            DrawMenu.DisplayMenuNoNumbers(new List<string> { "Welcome Wanderer.", "Lets create a new character." });
        }

        internal static void NewCharacter()
        {
            Console.Write("Character Name: ");
            Console.ResetColor();
        }

        internal static void WelcomeCharacter(Models.Player player)
        {
            Console.WriteLine($"Welcome {player.Name}");
            Sleep(1500);
        }

        internal static void NameIsTaken(string characterName)
        {
            Console.WriteLine($"The name \"{characterName}\" is taken.");
            Console.WriteLine("Try another name.");
            Sleep(1500);
        }
    }
}
