namespace Solitude2.Models
{
    /// <summary>
    /// AttackName, Bonus(dmg), Value(gold), Description.
    /// </summary>
    public class Weapon : Item
    {
        public Weapon() { }

        /// <summary>
        /// For creating a instance of a weapon without description.
        /// </summary>
        /// <param name="name">Weapon name.</param>
        /// <param name="bonus">Bonus damage.</param>
        /// <param name="goldValue">Gold value.</param>
        public Weapon(string name, float bonus, float goldValue)
        {
            this.Name = name;
            this.Bonus = bonus;
            this.Value = goldValue;
        }

        /// <summary>
        /// For creating a instance of a weapon with all props.
        /// </summary>
        /// <param name="name">Weapon name.</param>
        /// <param name="bonus">Bonus damage.</param>
        /// <param name="goldValue">Gold value.</param>
        /// <param name="description">Short description of the weapon.</param>
        public Weapon(string name, float bonus, float goldValue, string description)
        {
            this.Name = name;
            this.Bonus = bonus;
            this.Value = goldValue;
            this.Description = description;
        }
    }
}
