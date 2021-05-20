using System;
using System.Linq;
using Solitude2.Data;
using Solitude2.Models;
using Solitude2.Views.System;

namespace Solitude2.Controllers.System
{
    public static class NewGameController
    {
        public static Player CharacterCreation()
        {
            NewGameView.New();
            NewGameView.NewCharacter();
            var characterName = GetCharacterName();
            using var db = new MyDbContext();
            var player = db.Players.FirstOrDefault(p => p.Name == characterName);
            if (player != null)
            {
                StartGameController.CurrentGame();
                NewGameView.NameIsTaken(characterName);
                return null;
            }

            var starterWeapon = new Item("Wooden Sword", 20, 50, 0, "Made from splintered oak.", true, false, false);
            var newPlayer = new Player 
            { 
                Name = characterName,
                EquippedWeapon = starterWeapon
            };
            newPlayer.Inventory.Add(starterWeapon);
            db.Update(newPlayer);
            db.SaveChanges();
            NewGameView.WelcomeCharacter(newPlayer);
            return newPlayer;
        }

        private static string GetCharacterName()
        {
            return Console.ReadLine()?.Trim();
        }
    }
}
