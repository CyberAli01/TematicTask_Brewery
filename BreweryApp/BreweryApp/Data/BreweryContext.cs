using BreweryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BreweryApp.Data
{
    public class BreweryContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBeer> OrderBeers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=brewery_db;" +
                "Username=postgres;Password=my_password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderBeer>().HasKey(ob => new { ob.OrderId, ob.BeerId });
        }
    }
}