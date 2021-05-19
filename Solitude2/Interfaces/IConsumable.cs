namespace Solitude2.Interfaces
{
    public interface IConsumable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float GoldCost { get; set; }
        public float Bonus { get; set; }
    }
}
