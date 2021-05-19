using Solitude2.Interfaces;

namespace Solitude2.Models
{
    public class Item : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public float Bonus { get; set; }
    }
}
