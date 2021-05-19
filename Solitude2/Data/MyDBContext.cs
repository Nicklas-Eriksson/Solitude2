using Microsoft.EntityFrameworkCore;
using Solitude2.Models;

namespace Solitude2.Data
{
    /// <summary>
    /// Call this class to get a open connection to the database.
    /// </summary>
    public class MyDbContext : DbContext
    {
        private const string DatabaseName = "Solitude2";
        public DbSet<Player> Players { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Potion> Potions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"Server=.\SQLEXPRESS01;Database={DatabaseName};trusted_connection=true;");
        }
    }
}
