﻿using Solitude2.Data;
using System;
using static System.Int32;
using static System.Threading.Thread;

namespace Solitude2.Utility
{
    internal static class Helper
    {
        private static bool Success;
        private static string Input;
        private static int Number;

        internal static int GetUserInput(int maxOptions)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Option: ");
            Console.ResetColor();
            Input = Console.ReadLine()?.Trim().ToLower();
            if (Input == "b")
            {
                return 999;
            }
            Success = TryParse(Input, out Number);
            if (!Success || Number > maxOptions || Number <= 0)
            {
                Error();
                GetUserInput(maxOptions);
            }
            Console.ResetColor();
            return Number;
        }

        private static void Error()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Error, something went wrong. Try again.");
            Sleep(1300);
            Console.ResetColor();
        }

        public static void EmptyAllTables()
        {
            using var db = new MyDbContext();
            try
            {
                db.Items.Clear();
                db.Players.Clear();
                db.Monsters.Clear();
                db.SaveChanges();

                Console.WriteLine("Successfully deleted table contents.");
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public static void PressAnyKeyToContinue()
        {
            var time = DateTime.Now;
            while (time < time.AddMinutes(5))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Press any key to continue..");
                Console.ReadLine();
            }
        }
    }
}