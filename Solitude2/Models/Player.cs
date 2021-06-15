using Solitude2.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Solitude2.Controllers.Character;

namespace Solitude2.Models
{
    public class Player : IPlayer
    {
        public Player()
        {
            Inventory = new List<Item>();
            //Potions = new List<Item>();
            EquippedWeapon = new Item();
        }

        [Key] 
        public int ID { get; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool Alive { get; set; } = true;
        public float Gold { get; set; }
        public int CurrentLvl { get; set; } = 1;
        public int MaxLvl { get; set; } = 60;
        public float CurrentExp { get; set; }
        public float ExpReqForLvl { get; set; } = PlayerController.CurrentPlayer.CurrentLvl * 100; 
        public float CurrentHP { get; set; }
        public float MaxHP { get; set; } = PlayerController.CurrentPlayer.CurrentLvl * 150; 
        public float AttackPower { get; set; } = PlayerController.CurrentPlayer.CurrentLvl * 20;
        public float CriticalBonus => AttackPower * 0.4F;
        public float CriticalPercent => 5F; //1 in 5, used in Random.Next(1,5)
        public List<Item> Inventory { get; }
        //public List<Item> Potions { get; set; }
        public Item EquippedWeapon { get; init; }
        [ForeignKey("Inventories")]
        public int InventoryId { get; set; }
    }
}
