using CarRental.Domain.Entities.Cars;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace CarRental.Persistance.EntityFrameworks
{
    public class CarRentalContext :  DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> optionsBuilder)
            : base(optionsBuilder)
        {
            
        }


        public DbSet<Car> Cars => this.Set<Car>();
        public DbSet<Category> CarCategories => this.Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Jeep" },
                    new Category { Id = 2, Name = "Sedan" },
                    new Category { Id = 3, Name = "Furgon" }
                );


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }



    }
}
