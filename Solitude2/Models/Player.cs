using Solitude2.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Solitude2.Models
{
    public class Player : IPlayer
    {
        public Player()
        {
            Inventory = new List<Item>();
            Potions = new List<Item>();
            EquippedWeapon = new Item();
        }

        private float expReqForLvl;
        private float maxHp;
        private float attackPower;
        private float critBonus;

        [Key] 
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool Alive { get; set; } = true;
        public float Gold { get; set; }
        public int CurrentLvl { get; set; } = 1;
        public int MaxLvl { get; set; } = 60;
        public float CurrentExp { get; set; }
        public float ExpReqForLvl { get => expReqForLvl; set => expReqForLvl = CurrentLvl * 100; }
        public float CurrentHP { get; set; }
        public float MaxHP { get => maxHp; set => maxHp = CurrentLvl * 100; }
        public float AttackPower { get => attackPower; set => attackPower = CurrentLvl * 20; }
        public float CritBonus { get => critBonus; set => critBonus = AttackPower * 0.4F; }
        public float CritPercent { get; set; } = 5F; //1 in 5, used in Random.Next(1,5)
        public List<Item> Inventory { get; set; }
        public List<Item> Potions { get; set; }
        public Item EquippedWeapon { get; init; }
    }
}
