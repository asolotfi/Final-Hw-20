
using Microsoft.EntityFrameworkCore;
using HW_20.Domain.Entites.Car;
using HW_20.Domain.Entites.User;

namespace HW_20.Infrastructure.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<InspectionRequest> InspectionRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.Configuration.configurationstring);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<InspectionRequest>().HasOne(X => X.Car).WithMany(Y => Y.InspectionRequests).HasForeignKey(X => X.CarId).OnDelete(DeleteBehavior.Restrict);
            // Fluent API configurations
        }
    }

    //َAdd-Migration init
    //Update-Database
}

