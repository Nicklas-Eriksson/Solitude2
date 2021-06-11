﻿using Solitude2.Data;
using Solitude2.Models;
using Solitude2.Views.System;
using System;
using System.Linq;
using System.Threading;
using Solitude2.Controllers.Character;
using Solitude2.Facade;

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
            var inventory = new Inventory {ItemId = starterWeapon.ID, PlayerId = newPlayer.ID};
            Db.Update(inventory);
            Db.SaveChanges();
            SystemView.WelcomeCharacter(newPlayer);
            PlayerController.CurrentPlayer = newPlayer;
            return newPlayer;
        }

       private static Player CreateNewPlayer(string characterName, Item starterWeapon)
        {
            var newPlayer = new Player
            {
                Name = characterName,
                CurrentHP = 100,
                MaxHP = 100,
                Gold = 10,
                EquippedWeapon = starterWeapon,
                Inventory = { starterWeapon }
            };
            if (characterName == "Hakk") { newPlayer.IsAdmin = true; }

            return newPlayer;
        }
        
        private static Item CreateStarterWeapon()
        {
            var starterWeapon = new Item("Wooden Sword", 20, 50, 0, "Made from splintered oak.", true, false, false);
            var weaponInDatabase = Db.Items.FirstOrDefault(i => i.Name == starterWeapon.Name);
            if (weaponInDatabase == null)
            {
                Db.Update(starterWeapon);
                Db.SaveChanges();
                return starterWeapon;
            }

            return weaponInDatabase;
        }

        private static bool CheckForNameTaken(string characterName)
        {
            var player = Db.Players.FirstOrDefault(p => p.Name == characterName);
            if (player == null) { return false; }
            SystemView.NameIsTaken(characterName);
            SystemControllers.CurrentGame();
            return true;
        }

        private static string GetCharacterName()
        {
            var input = Console.ReadLine()?.Trim().ToLower();
            if (input is { Length: < 3 or > 8 })
            {
                SystemView.NameIsWrongLength();
                Thread.Sleep(2000);
                NewGame();
            }

            var substring = input.Remove(0, 1);
            var firstLetter = char.ToUpper(input[0]);
            var name = firstLetter + substring;
            return name;
        }
    }
}
