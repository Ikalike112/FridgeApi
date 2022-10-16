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
    [Migration("20221016164739_ModelConfigurations")]
    partial class ModelConfigurations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

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

                    b.HasData(
                        new
                        {
                            Id = new Guid("7870e84d-0f97-4196-bed7-19bd8ff40a63"),
                            FridgeModelId = new Guid("b12741d6-4ea0-4ce4-8a4e-3be45767b928"),
                            Name = "Electrolux Dima",
                            OwnerName = "Dima"
                        },
                        new
                        {
                            Id = new Guid("b97c170d-a6bf-4f26-8231-28d9025bf3ad"),
                            FridgeModelId = new Guid("b0463f44-af0c-434f-9667-c3bf6c9f8a93"),
                            Name = "ATLANT Vlad",
                            OwnerName = "Vlad"
                        },
                        new
                        {
                            Id = new Guid("557d35ef-ab80-4e17-a96c-2b65cf3dd7bf"),
                            FridgeModelId = new Guid("b12741d6-4ea0-4ce4-8a4e-3be45767b928"),
                            Name = "Electrolux Sasha",
                            OwnerName = "Sasha"
                        },
                        new
                        {
                            Id = new Guid("72e0a604-0877-4510-9701-f3b29ead9d9d"),
                            FridgeModelId = new Guid("d957b9be-b351-4629-a332-4841851aa395"),
                            Name = "Lg Inessa",
                            OwnerName = "Inessa"
                        },
                        new
                        {
                            Id = new Guid("78f6f534-8b95-44b7-88e3-6c395c53207e"),
                            FridgeModelId = new Guid("5d25ffb3-2f6b-4911-974d-a35f34ca7014"),
                            Name = "Indesid Roma",
                            OwnerName = "Roman"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("3bfd5e1c-8407-4d3e-b77b-30427468656e"),
                            Name = "Samsung RB34A7B4F35/WT",
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("d957b9be-b351-4629-a332-4841851aa395"),
                            Name = "LG DoorCooling+ GA-B509CQTL",
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("b12741d6-4ea0-4ce4-8a4e-3be45767b928"),
                            Name = "Electrolux KNT2LF18S",
                            Year = 2019
                        },
                        new
                        {
                            Id = new Guid("b0463f44-af0c-434f-9667-c3bf6c9f8a93"),
                            Name = "ATLANT ХМ 4307-000",
                            Year = 2017
                        },
                        new
                        {
                            Id = new Guid("2767f531-6eab-492b-99fa-839b826552e9"),
                            Name = "Indesit ITR 5200 W",
                            Year = 2020
                        });
                });

            modelBuilder.Entity("Domain.FridgeProducts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FridgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.HasIndex("ProductId");

                    b.ToTable("FridgeProducts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e0e12e03-2f7c-4a49-8b5c-602ce5786f28"),
                            FridgeId = new Guid("7870e84d-0f97-4196-bed7-19bd8ff40a63"),
                            ProductId = new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"),
                            Quantity = 3
                        },
                        new
                        {
                            Id = new Guid("ce9cca0d-44af-4ed0-94e4-ada2281d3cda"),
                            FridgeId = new Guid("7870e84d-0f97-4196-bed7-19bd8ff40a63"),
                            ProductId = new Guid("60aa9097-9f29-4f08-b0bd-b07a68b9da43"),
                            Quantity = 1
                        },
                        new
                        {
                            Id = new Guid("cf6e9d69-3eb9-4f73-ac12-25a09d016a6c"),
                            FridgeId = new Guid("7870e84d-0f97-4196-bed7-19bd8ff40a63"),
                            ProductId = new Guid("c30b9ac9-bdba-4edc-aa9c-ad3dda4814ae"),
                            Quantity = 15
                        },
                        new
                        {
                            Id = new Guid("05da7993-8bc2-4a92-a1c7-c282af54def9"),
                            FridgeId = new Guid("557d35ef-ab80-4e17-a96c-2b65cf3dd7bf"),
                            ProductId = new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"),
                            Quantity = 1
                        },
                        new
                        {
                            Id = new Guid("ec994091-00a1-41f5-bf8f-6abe3b4863a3"),
                            FridgeId = new Guid("557d35ef-ab80-4e17-a96c-2b65cf3dd7bf"),
                            ProductId = new Guid("5d25ffb3-2f6b-4911-974d-a35f34ca7014"),
                            Quantity = 2
                        },
                        new
                        {
                            Id = new Guid("14e4c28d-4ed9-41cd-95eb-f66f8c9bfe60"),
                            FridgeId = new Guid("557d35ef-ab80-4e17-a96c-2b65cf3dd7bf"),
                            ProductId = new Guid("c30b9ac9-bdba-4edc-aa9c-ad3dda4814ae"),
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("bffdc898-d59f-485d-a748-90df10a1e8c9"),
                            FridgeId = new Guid("b97c170d-a6bf-4f26-8231-28d9025bf3ad"),
                            ProductId = new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"),
                            Quantity = 0
                        },
                        new
                        {
                            Id = new Guid("3d0ee611-17e8-43b6-9ceb-ff117eaaa79c"),
                            FridgeId = new Guid("72e0a604-0877-4510-9701-f3b29ead9d9d"),
                            ProductId = new Guid("1b098f23-f8d9-4f7c-9385-20d620e176b6"),
                            Quantity = 3
                        },
                        new
                        {
                            Id = new Guid("52956ec3-022e-49de-b2c9-f2229478bbd8"),
                            FridgeId = new Guid("72e0a604-0877-4510-9701-f3b29ead9d9d"),
                            ProductId = new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"),
                            Quantity = 7
                        },
                        new
                        {
                            Id = new Guid("ffd7f7ce-dd5d-4610-93a9-a57c1c14b2df"),
                            FridgeId = new Guid("72e0a604-0877-4510-9701-f3b29ead9d9d"),
                            ProductId = new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"),
                            Quantity = 3
                        },
                        new
                        {
                            Id = new Guid("5c23a099-37f7-45e3-88f7-80119eb8a4f0"),
                            FridgeId = new Guid("78f6f534-8b95-44b7-88e3-6c395c53207e"),
                            ProductId = new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"),
                            Quantity = 3
                        },
                        new
                        {
                            Id = new Guid("681dd588-f9fd-4cf5-93c6-028adaa79f87"),
                            FridgeId = new Guid("78f6f534-8b95-44b7-88e3-6c395c53207e"),
                            ProductId = new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"),
                            Quantity = 7
                        },
                        new
                        {
                            Id = new Guid("e73af1a7-0f1a-4762-8d81-4fe406fa353b"),
                            FridgeId = new Guid("78f6f534-8b95-44b7-88e3-6c395c53207e"),
                            ProductId = new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"),
                            Quantity = 3
                        });
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("ImageSource")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5d25ffb3-2f6b-4911-974d-a35f34ca7014"),
                            DefaultQuantity = 1,
                            ImageSource = "https://localhost:5001/Images/sourcream.jpg",
                            Name = "Sour cream"
                        },
                        new
                        {
                            Id = new Guid("413ce5ba-f360-4c4c-8f7e-cd26667fe5ff"),
                            DefaultQuantity = 1,
                            ImageSource = "https://localhost:5001/Images/curd.webp",
                            Name = "Curd"
                        },
                        new
                        {
                            Id = new Guid("60aa9097-9f29-4f08-b0bd-b07a68b9da43"),
                            DefaultQuantity = 1,
                            ImageSource = "https://localhost:5001/Images/bread.jpg",
                            Name = "Bread"
                        },
                        new
                        {
                            Id = new Guid("a3db9cb6-4d70-44fc-b140-969b5594a56e"),
                            DefaultQuantity = 5,
                            ImageSource = "https://localhost:5001/Images/cucumbers.jpg",
                            Name = "Сucumbers"
                        },
                        new
                        {
                            Id = new Guid("c30b9ac9-bdba-4edc-aa9c-ad3dda4814ae"),
                            DefaultQuantity = 4,
                            ImageSource = "https://localhost:5001/Images/apples.jpg",
                            Name = "Apples"
                        },
                        new
                        {
                            Id = new Guid("1b098f23-f8d9-4f7c-9385-20d620e176b6"),
                            DefaultQuantity = 1,
                            ImageSource = "https://localhost:5001/Images/buckwheat.webp",
                            Name = "Buckwheat"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1b0f3777-e2ce-4da4-abf9-730cd4beeb6c",
                            ConcurrencyStamp = "adec2842-d831-4043-9cc1-1c0ea90e66ef",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "195896e6-fa3e-4958-b5c8-6b1ce4ab320d",
                            ConcurrencyStamp = "9dac0541-f95b-4081-a624-0b8901b97acf",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
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

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Fridge", b =>
                {
                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("Domain.FridgeModel", b =>
                {
                    b.Navigation("Fridges");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Navigation("FridgeProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
