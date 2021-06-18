using System;

namespace Solitude2.Prints
{
    /// <summary>
    /// The ASCII-logotypes were made by Patorjk.com
    /// Font: Doom
    /// Character width: Default
    /// Character height: Default
    /// </summary>
    internal static class Logotype
    {
        internal static void MadeByNicklas()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@" ______         _   _ _      _    _             _____     _ _                        
 | ___ \       | \ | (_)    | |  | |           |  ___|   (_) |                       
 | |_/ /_   _  |  \| |_  ___| | _| | __ _ ___  | |__ _ __ _| | _____ ___  ___  _ __  
 | ___ \ | | | | . ` | |/ __| |/ / |/ _` / __| |  __| '__| | |/ / __/ __|/ _ \| '_ \ 
 | |_/ / |_| | | |\  | | (__|   <| | (_| \__ \ | |__| |  | |   <\__ \__ \ (_) | | | |
 \____/ \__, | \_| \_/_|\___|_|\_\_|\__,_|___/ \____/_|  |_|_|\_\___/___/\___/|_| |_|
         __/ |                                                                       
        |___/                                                                        ");
            Console.ResetColor();
        }

        internal static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _    _      _                          
 | |  | |    | |                         
 | |  | | ___| | ___ ___  _ __ ___   ___ 
 | |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \
 \  /\  /  __/ | (_| (_) | | | | | |  __/
  \/  \/ \___|_|\___\___/|_| |_| |_|\___|
                                        
                                        ");
            Console.ResetColor();
        }

        internal static void Weapons()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _    _                                  
 | |  | |                                 
 | |  | | ___  __ _ _ __   ___  _ __  ___ 
 | |/\| |/ _ \/ _` | '_ \ / _ \| '_ \/ __|
 \  /\  /  __/ (_| | |_) | (_) | | | \__ \
  \/  \/ \___|\__,_| .__/ \___/|_| |_|___/
                   | |                    
                   |_|                    ");
            Console.ResetColor();
        }

        internal static void PowerUps()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@" ______                        _   _           
 | ___ \                      | | | |          
 | |_/ /____      _____ _ __  | | | |_ __  ___ 
 |  __/ _ \ \ /\ / / _ \ '__| | | | | '_ \/ __|
 | | | (_) \ V  V /  __/ |    | |_| | |_) \__ \
 \_|  \___/ \_/\_/ \___|_|     \___/| .__/|___/
                                    | |        
                                    |_|        ");
            Console.ResetColor();
        }

        internal static void Potions()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@" ______     _   _                 
 | ___ \   | | (_)                
 | |_/ /__ | |_ _  ___  _ __  ___ 
 |  __/ _ \| __| |/ _ \| '_ \/ __|
 | | | (_) | |_| | (_) | | | \__ \
 \_|  \___/ \__|_|\___/|_| |_|___/
                                  
                                 ");
            Console.ResetColor();
        }

        internal static void LoadGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _                     _   _____                      
 | |                   | | |  __ \                     
 | |     ___   __ _  __| | | |  \/ __ _ _ __ ___   ___ 
 | |    / _ \ / _` |/ _` | | | __ / _` | '_ ` _ \ / _ \
 | |___| (_) | (_| | (_| | | |_\ \ (_| | | | | | |  __/
 \_____/\___/ \__,_|\__,_|  \____/\__,_|_| |_| |_|\___|
                                                      
                                                      ");
            Console.ResetColor();
        }
        internal static void LoadingGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var loadingGame = (@"  _                     _   _____                      
 | |                   | | |  __ \                     
 | |     ___   __ _  __| | | |  \/ __ _ _ __ ___   ___ 
 | |    / _ \ / _` |/ _` | | | __ / _` | '_ ` _ \ / _ \
 | |___| (_) | (_| | (_| | | |_\ \ (_| | | | | | |  __/
 \_____/\___/ \__,_|\__,_|  \____/\__,_|_| |_| |_|\___|     ");
            foreach (var letter in loadingGame)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(6);
            }
            System.Threading.Thread.Sleep(500);
            Console.ResetColor();
        }

        internal static void NewGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _   _                 _____                      
 | \ | |               |  __ \                     
 |  \| | _____      __ | |  \/ __ _ _ __ ___   ___ 
 | . ` |/ _ \ \ /\ / / | | __ / _` | '_ ` _ \ / _ \
 | |\  |  __/\ V  V /  | |_\ \ (_| | | | | | |  __/
 \_| \_/\___| \_/\_/    \____/\__,_|_| |_| |_|\___|
                                                  
                                                  ");
            Console.ResetColor();
        }

        internal static void Save()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var saveGame = $@"  _____             _               _____                      
 /  ___|           (_)             |  __ \                     
 \ `--.  __ ___   ___ _ __   __ _  | |  \/ __ _ _ __ ___   ___ 
  `--. \/ _` \ \ / / | '_ \ / _` | | | __ / _` | '_ ` _ \ / _ \
 /\__/ / (_| |\ V /| | | | | (_| | | |_\ \ (_| | | | | | |  __/
 \____/ \__,_| \_/ |_|_| |_|\__, |  \____/\__,_|_| |_| |_|\___|
                             __/ |                             
                            |___/                              ";
            foreach (var letter in saveGame)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(17);
            }
            System.Threading.Thread.Sleep(500);
            Console.ResetColor();
        }

        internal static void IronSkillet()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _____                  _____ _    _ _ _      _   
 |_   _|                /  ___| |  (_) | |    | |  
   | | _ __ ___  _ __   \ `--.| | ___| | | ___| |_ 
   | || '__/ _ \| '_ \   `--. \ |/ / | | |/ _ \ __|
  _| || | | (_) | | | | /\__/ /   <| | | |  __/ |_ 
  \___/_|  \___/|_| |_| \____/|_|\_\_|_|_|\___|\__|
                                                  
                                                  ");
            Console.ResetColor();
        }

        internal static void Solitude()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _____       _ _ _             _        _____ 
 /  ___|     | (_) |           | |      / __  \
 \ `--.  ___ | |_| |_ _   _  __| | ___  `' / /'
  `--. \/ _ \| | | __| | | |/ _` |/ _ \   / /  
 /\__/ / (_) | | | |_| |_| | (_| |  __/ ./ /___
 \____/ \___/|_|_|\__|\__,_|\__,_|\___| \_____/
                                              
                                              ");
            Console.ResetColor();
        }

        internal static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@" ___  ___      _        ___  ___                 
 |  \/  |     (_)       |  \/  |                 
 | .  . | __ _ _ _ __   | .  . | ___ _ __  _   _ 
 | |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |
 | |  | | (_| | | | | | | |  | |  __/ | | | |_| |
 \_|  |_/\__,_|_|_| |_| \_|  |_/\___|_| |_|\__,_|
                                                
                                                ");
            Console.ResetColor();
        }

        internal static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _____     _ _     _____                      
 |  ___|   (_) |   |  __ \                     
 | |____  ___| |_  | |  \/ __ _ _ __ ___   ___ 
 |  __\ \/ / | __| | | __ / _` | '_ ` _ \ / _ \
 | |___>  <| | |_  | |_\ \ (_| | | | | | |  __/
 \____/_/\_\_|\__|  \____/\__,_|_| |_| |_|\___|
                                              
                                              ");
            Console.ResetColor();
        }

        internal static void Inventory()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _____                     _                   
 |_   _|                   | |                  
   | | _ ____   _____ _ __ | |_ ___  _ __ _   _ 
   | || '_ \ \ / / _ \ '_ \| __/ _ \| '__| | | |
  _| || | | \ V /  __/ | | | || (_) | |  | |_| |
  \___/_| |_|\_/ \___|_| |_|\__\___/|_|   \__, |
                                           __/ |
                                          |___/ ");
            Console.ResetColor();
        }

        internal static void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _____                        _____                
 |  __ \                      |  _  |               
 | |  \/ __ _ _ __ ___   ___  | | | |_   _____ _ __ 
 | | __ / _` | '_ ` _ \ / _ \ | | | \ \ / / _ \ '__|
 | |_\ \ (_| | | | | | |  __/ \ \_/ /\ V /  __/ |   
  \____/\__,_|_| |_| |_|\___|  \___/  \_/ \___|_|   
                                                   
                                                   ");
            Console.ResetColor();
        }

        internal static void AdminPanel()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"   ___      _           _        ______                _ 
  / _ \    | |         (_)       | ___ \              | |
 / /_\ \ __| |_ __ ___  _ _ __   | |_/ /_ _ _ __   ___| |
 |  _  |/ _` | '_ ` _ \| | '_ \  |  __/ _` | '_ \ / _ \ |
 | | | | (_| | | | | | | | | | | | | | (_| | | | |  __/ |
 \_| |_/\__,_|_| |_| |_|_|_| |_| \_|  \__,_|_| |_|\___|_|
                                                        
                                                        ");
            Console.ResetColor();
        }

        internal static void Encounter()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _____                            _            
 |  ___|                          | |           
 | |__ _ __   ___ ___  _   _ _ __ | |_ ___ _ __ 
 |  __| '_ \ / __/ _ \| | | | '_ \| __/ _ \ '__|
 | |__| | | | (_| (_) | |_| | | | | ||  __/ |   
 \____/_| |_|\___\___/ \__,_|_| |_|\__\___|_|   
                                               
                                               ");
            Console.ResetColor();
        }

        internal static void Victory()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  _   _ _      _                   
 | | | (_)    | |                  
 | | | |_  ___| |_ ___  _ __ _   _ 
 | | | | |/ __| __/ _ \| '__| | | |
 \ \_/ / | (__| || (_) | |  | |_| |
  \___/|_|\___|\__\___/|_|   \__, |
                              __/ |
                             |___/ ");
            Console.ResetColor();
        }

        internal static void LoggingOut()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var loadingGame = (@"  _                       _               _____       _   
 | |                     (_)             |  _  |     | |  
 | |     ___   __ _  __ _ _ _ __   __ _  | | | |_   _| |_ 
 | |    / _ \ / _` |/ _` | | '_ \ / _` | | | | | | | | __|
 | |___| (_) | (_| | (_| | | | | | (_| | \ \_/ / |_| | |_ 
 \_____/\___/ \__, |\__, |_|_| |_|\__, |  \___/ \__,_|\__|
               __/ | __/ |         __/ |                  
              |___/ |___/         |___/                   ");
            foreach (var letter in loadingGame)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(6);
            }
            System.Threading.Thread.Sleep(500);
            Console.ResetColor();
        }
    }
}
