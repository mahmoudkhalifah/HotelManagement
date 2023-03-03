﻿// <auto-generated />
using Login.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Login.Migrations
{
    [DbContext(typeof(LoginContext))]
    [Migration("20230303140922_AdminAndRoomServiceAdded")]
    partial class AdminAndRoomServiceAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Login.Entity.Person", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Username");

                    b.ToTable("People");

                    b.HasDiscriminator<bool>("IsAdmin");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Login.Entity.Admin", b =>
                {
                    b.HasBaseType("Login.Entity.Person");

                    b.HasDiscriminator().HasValue(true);
                });

            modelBuilder.Entity("Login.Entity.RoomService", b =>
                {
                    b.HasBaseType("Login.Entity.Person");

                    b.HasDiscriminator().HasValue(false);
                });
#pragma warning restore 612, 618
        }
    }
}
