using Solitude2.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Solitude2.Models
{
    /// <summary>
    /// AttackName, Level, GoldDrop, ExpDrop, Item-Drop, TalentDrop, Description, Dmg.
    /// </summary>
    public class Monster : IEnemy
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = "Entity Unknown";
        public string AttackName { get; set; } = "Unknown";
        public int Level { get; set; } = default;
        public bool Alive { get; set; } = true;
        public float GoldDrop { get => GoldDrop; set => GoldDrop = Level * 100; }
        public float ExpDrop { get => ExpDrop; set => ExpDrop = Level * 100; }
        public Item Drop { get; set; } = null;
        public int TalentDrop { get; set; } = 1;
        public string Description { get; set; } = "Non";
        public float MaxHp { get; set; } = default;
        public float CurrentHp { get; set; } = default;
        public float Dmg { get => Dmg; set => Dmg = Level * 10F; }
    }
}
