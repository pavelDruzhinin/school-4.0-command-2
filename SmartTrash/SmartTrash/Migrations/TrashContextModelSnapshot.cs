﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartTrash.Data;

namespace SmartTrash.Migrations
{
    [DbContext(typeof(TrashContext))]
    partial class TrashContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SmartTrash.Models.GarbageTruck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("MaintananceCostFactor");

                    b.Property<string>("Model");

                    b.Property<string>("NumberPlate")
                        .IsRequired();

                    b.Property<decimal>("Volume");

                    b.HasKey("Id");

                    b.HasAlternateKey("NumberPlate")
                        .HasName("AlternateKey_NumberPlate");

                    b.ToTable("GarbageTrucks");

                    b.HasData(
                        new { Id = 1, MaintananceCostFactor = 15m, Model = "Камаз-65115 КО-440В1", NumberPlate = "B546OP10", Volume = 85500m },
                        new { Id = 2, MaintananceCostFactor = 15m, Model = "Камаз-65115 КО-440-5", NumberPlate = "M182AK10", Volume = 49500m },
                        new { Id = 3, MaintananceCostFactor = 13m, Model = "Камаз-5325 КО-440В2", NumberPlate = "O334XT10", Volume = 80750m },
                        new { Id = 4, MaintananceCostFactor = 10m, Model = "Маз-4380 КО-440-4М", NumberPlate = "K937ET10", Volume = 30250m }
                    );
                });

            modelBuilder.Entity("SmartTrash.Models.IdentityModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SmartTrash.Models.IdentityModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SmartTrash.Models.IdentityModels.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("SmartTrash.Models.WasteCollectionArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("FilledVolume");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<decimal>("Volume");

                    b.HasKey("Id");

                    b.ToTable("WasteCollectionAreas");

                    b.HasData(
                        new { Id = 1, FilledVolume = 136m, Latitude = 61.79087f, Longitude = 34.36776f, Name = "Мусорная площадка 1", Volume = 1100m },
                        new { Id = 2, FilledVolume = 541m, Latitude = 61.78953f, Longitude = 34.37f, Name = "Мусорная площадка 2", Volume = 1100m },
                        new { Id = 3, FilledVolume = 748m, Latitude = 61.79012f, Longitude = 34.3732f, Name = "Мусорная площадка 3", Volume = 1100m },
                        new { Id = 4, FilledVolume = 134m, Latitude = 61.8019f, Longitude = 34.34448f, Name = "Мусорная площадка 4", Volume = 1100m },
                        new { Id = 5, FilledVolume = 814m, Latitude = 61.80639f, Longitude = 34.33181f, Name = "Мусорная площадка 5", Volume = 1100m },
                        new { Id = 6, FilledVolume = 4m, Latitude = 61.80109f, Longitude = 34.32463f, Name = "Мусорная площадка 6", Volume = 1100m },
                        new { Id = 7, FilledVolume = 34m, Latitude = 61.79863f, Longitude = 34.32402f, Name = "Мусорная площадка 7", Volume = 1100m },
                        new { Id = 8, FilledVolume = 74m, Latitude = 61.7968f, Longitude = 34.33304f, Name = "Мусорная площадка 8", Volume = 1100m },
                        new { Id = 9, FilledVolume = 434m, Latitude = 61.7935f, Longitude = 34.34128f, Name = "Мусорная площадка 9", Volume = 1100m },
                        new { Id = 10, FilledVolume = 237m, Latitude = 61.79022f, Longitude = 34.34173f, Name = "Мусорная площадка 10", Volume = 1100m },
                        new { Id = 11, FilledVolume = 321m, Latitude = 61.78689f, Longitude = 34.34767f, Name = "Мусорная площадка 11", Volume = 1100m },
                        new { Id = 12, FilledVolume = 432m, Latitude = 61.78534f, Longitude = 34.34936f, Name = "Мусорная площадка 12", Volume = 1100m },
                        new { Id = 13, FilledVolume = 36m, Latitude = 61.78621f, Longitude = 34.35516f, Name = "Мусорная площадка 13", Volume = 1100m },
                        new { Id = 14, FilledVolume = 267m, Latitude = 61.78695f, Longitude = 34.36066f, Name = "Мусорная площадка 14", Volume = 1100m },
                        new { Id = 15, FilledVolume = 103m, Latitude = 61.78845f, Longitude = 34.36686f, Name = "Мусорная площадка 15", Volume = 1100m },
                        new { Id = 16, FilledVolume = 365m, Latitude = 61.78819f, Longitude = 34.37271f, Name = "Мусорная площадка 16", Volume = 1100m },
                        new { Id = 17, FilledVolume = 178m, Latitude = 61.78965f, Longitude = 34.37432f, Name = "Мусорная площадка 17", Volume = 1100m },
                        new { Id = 18, FilledVolume = 613m, Latitude = 61.79088f, Longitude = 34.37862f, Name = "Мусорная площадка 18", Volume = 1100m },
                        new { Id = 19, FilledVolume = 345m, Latitude = 61.79287f, Longitude = 34.37489f, Name = "Мусорная площадка 19", Volume = 1100m },
                        new { Id = 20, FilledVolume = 197m, Latitude = 61.80373f, Longitude = 34.34081f, Name = "Мусорная площадка 20", Volume = 1100m }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("SmartTrash.Models.IdentityModels.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SmartTrash.Models.IdentityModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SmartTrash.Models.IdentityModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("SmartTrash.Models.IdentityModels.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartTrash.Models.IdentityModels.UserRole", b =>
                {
                    b.HasOne("SmartTrash.Models.IdentityModels.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartTrash.Models.IdentityModels.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
