using System;
using System.Collections.Generic;
using Solitude2.Prints;
using Solitude2.Models;
using Solitude2.Views.SetCursorPosition;
using static System.Threading.Thread;

namespace Solitude2.Views.System
{
    public static class LoadGameView
    {
        /// <summary>
        /// Prompts user to load a previous game.
        /// </summary>
        public static void Load()
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
    }
}
