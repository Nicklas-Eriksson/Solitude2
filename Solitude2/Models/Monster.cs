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
        public int ID { get; }
        public string Name { get; set; } = "Entity Unknown";
        public string AttackName { get; set; } = "Unknown";
        public int Level { get; set;  }
        public bool Alive { get; set; } = true;
        public float GoldDrop => Level * 100;
        public float ExpDrop => Level * 100;
        public Item Drop { get; set; } = null;
        public string Description { get; set; } = "Non";
        public float MaxHp => Level * 100;
        public float CurrentHp { get; set; }
        public float Dmg => Level * 10F;
    }
}
