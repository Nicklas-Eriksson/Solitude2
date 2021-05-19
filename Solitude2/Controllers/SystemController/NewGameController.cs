using System;
using System.Linq;
using Solitude2.Data;
using Solitude2.Models;
using Solitude2.Views.SystemView;

namespace Solitude2.Controllers.SystemController
{
    public static class NewGameController
    {
        public static Player CharacterCreation()
        {
            NewGameView.New();
            NewGameView.NewCharacter();
            var characterName = CharacterName();
            using var db = new MyDbContext();
            var player = db.Players.FirstOrDefault(p => p.Name == characterName);
            if (player != null)
            {
                StartGameController.CurrentGame();
                NewGameView.NameIsTaken(characterName);
                return null;
            }

            var starterWeapon = new Weapon("Wooden Sword", 20, 50, "Made from splintered oak.");
            var newPlayer = new Player { Name = characterName, EquippedWeapon = starterWeapon};
            db.Update(newPlayer);
            db.SaveChanges();
            NewGameView.WelcomeCharacter();
            return newPlayer;
        }

        private static string CharacterName()
        {
            return Console.ReadLine()?.Trim();
        }
    }
}
