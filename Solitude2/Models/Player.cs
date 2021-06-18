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
            Inventory = new List<IItem>();
            EquippedWeapon = new Item();
        }

        [Key] 
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool Alive { get; set; } = true;
        public float Gold { get; set; }
        public int CurrentLvl { get; set; } = 1;
        public int MaxLvl { get; set; } = 60;
        public float CurrentExp { get; set; }
        public float ExpReqForLvl => CurrentLvl * 100; 
        public float CurrentHP { get; set; }
        public float MaxHP { get; set; } = 150; 
        public float AttackPower { get; set; } = 20;
        public float CriticalBonus => AttackPower * 0.4F;
        public float CriticalPercent => 5F; //1 in 5, used in Random.Next(1,5)
        public List<IItem> Inventory { get; }
        public Item EquippedWeapon { get; init; }
        [ForeignKey("Inventories")]
        public int InventoryId { get; set; }
    }
}
