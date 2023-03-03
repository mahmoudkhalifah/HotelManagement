using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Entity;
using Microsoft.EntityFrameworkCore;

namespace Login.DBContext
{
    class LoginContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=HotelManagementLogin;Trusted_Connection=True;Encrypt=False;");
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
    }
}
