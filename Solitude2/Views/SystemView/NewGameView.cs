using System;
using System.Collections.Generic;
using Solitude2.Controllers.SystemController;
using Solitude2.Models;
using Solitude2.Prints;
using static System.Threading.Thread;

namespace Solitude2.Views.SystemView
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
            Frame.NewNoNr(new List<string> { "Welcome Wanderer.", "Lets create a new character."});
        }

        public static void NewCharacter()
        {
            Console.Write("Character Name:");
        }

        internal static void WelcomeCharacter()
        {
            Console.WriteLine($"Welcome {StartGameController.CurrentPlayer.Name}");
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
