﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(FridgeDbContext))]
    [Migration("20221006084415_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FridgeModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("OwnerName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("FridgeModelId");

                    b.ToTable("Fridges");
                });

            modelBuilder.Entity("Domain.FridgeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FridgeModels");
                });

            modelBuilder.Entity("Domain.FridgeProducts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.HasIndex("ProductsId");

                    b.ToTable("FridgeProducts");
                });

            modelBuilder.Entity("Domain.Products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("DefaultQuantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Fridge", b =>
                {
                    b.HasOne("Domain.FridgeModel", "FridgeModel")
                        .WithMany("Fridges")
                        .HasForeignKey("FridgeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FridgeModel");
                });

            modelBuilder.Entity("Domain.FridgeProducts", b =>
                {
                    b.HasOne("Domain.Fridge", "Fridge")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Products", "Products")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Fridge", b =>
                {
                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("Domain.FridgeModel", b =>
                {
                    b.Navigation("Fridges");
                });

            modelBuilder.Entity("Domain.Products", b =>
                {
                    b.Navigation("FridgeProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
