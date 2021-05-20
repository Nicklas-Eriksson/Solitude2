//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Solitude2.Prints
//{
//    public static class Frame
//    {
//        public static void New(List<string> option)
//        {
//            var longestString = option.Aggregate(".", (max, cur) => max.Length > cur.Length ? max : cur);
//            List<char> row = new();
//            for (int i = 0; i < longestString.Length; i++)
//            {
//                row.Add('═');
//            }
//            string combinedString = string.Join("", row.ToArray());
//            Console.WriteLine($"╔═{combinedString}═══");
//            for (int i = 0; i < option.Count; i++)
//            {
//                Console.WriteLine($"║ {i + 1}: {option[i]} ");
//            }
//            Console.WriteLine($"╚═{combinedString}═══");
//        }

//        public static void NewNoNr(List<string> option)
//        {
//            var longestString = option.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
//            List<char> row = new();
//            for (int i = 0; i < longestString.Length; i++)
//            {
//                row.Add('═');
//            }
//            string combindedString = string.Join("═", row.ToArray());
//            Console.WriteLine($"╔═{combindedString}═");
//            for (int i = 0; i < option.Count; i++)
//            {
//                Console.WriteLine($"║ {option[i]} ");
//            }
//            Console.WriteLine($"╚═{combindedString}═");
//        }
//    }
//}
