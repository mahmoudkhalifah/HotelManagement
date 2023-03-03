﻿
using Login.Entity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace Login.DBContext
{
    public class LoginContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["loginDB"].ConnectionString);
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