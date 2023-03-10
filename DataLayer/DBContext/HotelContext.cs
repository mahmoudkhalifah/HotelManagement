
using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace DataLayer.DBContext
{
    public class HotelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["hotelDB"].ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasDiscriminator(p=>p.IsAdmin)
                .HasValue<Admin>(true)
                .HasValue<RoomService>(false);
        }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<RoomService> RoomServices { get; set; }

        
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        
    }
}
