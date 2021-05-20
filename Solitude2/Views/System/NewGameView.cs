using System;
using System.Collections.Generic;
using Solitude2.Prints;
using Solitude2.Views.SetCursorPosition;
using static System.Threading.Thread;

namespace Solitude2.Views.System
{
    public static class NewGameView
    {
        /// <summary>
        /// Prompt to create a new game.
        /// </summary>
        public static void New()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.NewGame();
            DrawMenu.DisplayMenuNoNumbers(new List<string> { "Welcome Wanderer.", "Lets create a new character."});
        }

        public static void NewCharacter()
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
