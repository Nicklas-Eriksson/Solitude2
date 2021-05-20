using System;
using System.Collections.Generic;

namespace Solitude2.Views.SetCursorPosition
{
    internal static class DrawMenu
    {
        private static int Left, Top;

        internal static void DisplayMenu(IEnumerable<string> options)
        {
            DrawMenuFrame();
            DrawMenuOptions(options);
        }

        internal static void DisplayMenuNoNumbers(IEnumerable<string> options)
        {
            DrawMenuFrame();
            DrawMenuOptionsNoNumbers(options);
        }

        private static void DrawMenuFrame()
        {
            Left = 2;
            Top = 7;
            Console.SetCursorPosition(73, Top);
            Console.WriteLine("╔══════════════════════════╗");
            Console.SetCursorPosition(Left, Top + 1);
            Console.WriteLine("║                          ║");
            Console.SetCursorPosition(Left, Top + 2);
            Console.WriteLine("╚══════════════════════════╝");
        }

        private static void DrawMenuOptions(IEnumerable<string> options)
        {
            var index = 1;
            foreach (var option in options)
            {
                Console.SetCursorPosition(Left + 2, Top + index);
                Console.WriteLine($"{index}: {option}");
                index++;
            }
        }

        private static void DrawMenuOptionsNoNumbers(IEnumerable<string> options)
        {
            var index = 1;
            foreach (var option in options)
            {
                Console.SetCursorPosition(Left + 2, Top + index);
                Console.WriteLine($"{option}");
                index++;
            }
        }
    }
}
