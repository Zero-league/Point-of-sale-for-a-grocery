﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.DataSource;

namespace POS.DataSource.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191206113310_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("POS.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemCatogaryId")
                        .HasColumnType("int");

                    b.Property<int>("ItemCost")
                        .HasColumnType("int");

                    b.Property<int>("ItemLocationId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QTY")
                        .HasColumnType("int");

                    b.Property<int>("RetailPrice")
                        .HasColumnType("int");

                    b.Property<int>("UnitmesurementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemCatogaryId");

                    b.HasIndex("ItemLocationId");

                    b.HasIndex("UnitmesurementId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("POS.Models.ItemCatogary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CatogaryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemCatogaries");
                });

            modelBuilder.Entity("POS.Models.ItemLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemLocations");
                });

            modelBuilder.Entity("POS.Models.Unitmesurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("mesurementName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Unitmesurements");
                });

            modelBuilder.Entity("POS.Models.Inventory", b =>
                {
                    b.HasOne("POS.Models.ItemCatogary", "ItemCatogary")
                        .WithMany()
                        .HasForeignKey("ItemCatogaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Models.ItemLocation", "ItemLocation")
                        .WithMany()
                        .HasForeignKey("ItemLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Models.Unitmesurement", "Unitmesurement")
                        .WithMany()
                        .HasForeignKey("UnitmesurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
