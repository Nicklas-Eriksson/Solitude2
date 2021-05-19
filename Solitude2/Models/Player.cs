using Solitude2.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Solitude2.Models
{
    public class Player : IId, INameable, ILevelable, IStatable
    {
        private float expForLvl { get; set; }
        private float maxHp { get; set; }
        private float attackPower { get; set; }
        private float critBonus { get; set; }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = "Unknown";
        public bool Alive { get; set; } = true;
        public float Gold { get; set; } = default;
        public int CurrentLvl { get; set; } = 1;
        public int MaxLvl { get; set; } = 60;
        public float CurrentExp { get; set; } = 0;
        public float ExpReqForLvl { get => expForLvl; set => expForLvl = CurrentLvl * 100; }
        public float CurrentHP { get; set; } = default;
        public float MaxHP { get => maxHp; set => maxHp = CurrentLvl * 100; }
        public float AttackPower { get => attackPower; set => attackPower = CurrentLvl * 20; }
        public float CritBonus { get => critBonus; set => critBonus = AttackPower * 0.4F; }
        public float CritPercent { get; set; } = 5F; //1 in 5, used in Random.Next(1,5)
        public List<Potion> Potions { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Item> Inventory { get; set; }
        public Weapon EquippedWeapon { get; set; } = null;
    }
}
