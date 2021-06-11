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
            Console.Write(" Option: ");
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
            Console.WriteLine(" Error, something went wrong. Try again.");
            Sleep(1300);
            Console.ResetColor();
        }

        public static void PressEnterToContinue()
        {
            var time = DateTime.Now;

            while (time < time.AddMinutes(5))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(" Press \"Enter\" to continue..");
                var readKey = Console.ReadKey(true);
                if (readKey.Key == ConsoleKey.Enter) break;
            }
        }

        public static int SpecificCommand()
        {
            var input = Console.ReadLine()?.ToLower().Trim();

            return input switch
            {
                "empty all tables" => 1,
                "back" => 2,
                _ => 3
            };
        }
    }
}
