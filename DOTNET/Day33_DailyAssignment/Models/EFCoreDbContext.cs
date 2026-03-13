using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace CountryStateCity.Models
{
    public class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuring the database connection
            optionsBuilder.UseSqlServer(@"Server=RITHU-PC;Database=EFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Countries Master Data	
           
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "India", CountryCode = "IND" },
                new Country { CountryId = 2, CountryName = "USA", CountryCode = "US" }
            );
            // Seed States Master Data
            modelBuilder.Entity<State>().HasData(
                new State { StateId = 1, StateName = "Telangana", CountryId = 1 },
                new State { StateId = 2, StateName = "Karnataka", CountryId = 1 },
                new State { StateId = 3, StateName = "California", CountryId = 2 }
            );
            // Seed Cities Master Data
            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, CityName = "Hyderabad", StateId = 1 },
                new City { CityId = 2, CityName = "warangal", StateId = 1 },
                new City { CityId = 3, CityName = "Banglore", StateId = 2 },
                new City { CityId = 4, CityName = "San Francisco", StateId = 3 }
            );
        }
        // DbSets representing the tables
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
