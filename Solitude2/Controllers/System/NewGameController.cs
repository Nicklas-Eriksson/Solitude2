using Solitude2.Data;
using Solitude2.Models;
using Solitude2.Views.System;
using System;
using System.Linq;

namespace Solitude2.Controllers.System
{
    public static class NewGameController
    {
        private static readonly MyDbContext Db = new();

        internal static Player NewGame()
        {
            SystemView.New();
            SystemView.NewCharacter();
            return CharacterCreation();
        }

        private static Player CharacterCreation()
        {
            var characterName = GetCharacterName();
            if (CheckForNameTaken(characterName)) return null;
            var starterWeapon = CreateStarterWeapon();
            var newPlayer = CreateNewPlayer(characterName, starterWeapon);
            Db.Update(newPlayer);
            Db.SaveChanges();
            SystemView.WelcomeCharacter(newPlayer);
            return newPlayer;
        }

        private static Player CreateNewPlayer(string characterName, Item starterWeapon)
        {
            var newPlayer = new Player
            {
                Name = characterName,
                EquippedWeapon = starterWeapon
            };
            if (characterName == "Hakk") { newPlayer.IsAdmin = true; }
            newPlayer.Inventory.Add(starterWeapon);
            return newPlayer;
        }

        private static Item CreateStarterWeapon()
        {
            var starterWeapon = new Item("Wooden Sword", 20, 50, 0, "Made from splintered oak.", true, false, false);
            return starterWeapon;
        }

        private static bool CheckForNameTaken(string characterName)
        {
            var player = Db.Players.FirstOrDefault(p => p.Name == characterName);
            if (player == null) return false;
            SystemView.NameIsTaken(characterName);
            SystemControllers.CurrentGame();
            return true;
        }

        private static string GetCharacterName() => Console.ReadLine()?.Trim();
    }
}
