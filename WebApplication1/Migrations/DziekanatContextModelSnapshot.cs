﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.DAL.Contexts;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DziekanatContext))]
    partial class DziekanatContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("WebApplication1.DAL.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdresZamieszkania")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugieImie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerIndeksu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("WebApplication1.DAL.Models.Zajecia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NazwaZajec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TerminZajec")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Zajecia");
                });
#pragma warning restore 612, 618
        }
    }
}
