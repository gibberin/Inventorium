﻿// <auto-generated />
using System;
using Inventorium.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventorium.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191105054940_Linked_App_With_Project")]
    partial class Linked_App_With_Project
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventoriumLib.Application", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<long>("Edition");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<Guid?>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("InventoriumLib.BinRack", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("Depth");

                    b.Property<long>("Edition");

                    b.Property<int>("Height");

                    b.Property<Guid?>("LocationID");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<int>("Width");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.ToTable("BinRack");
                });

            modelBuilder.Entity("InventoriumLib.Item", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AssignmentID");

                    b.Property<Guid?>("BinID");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateOfAcquisition");

                    b.Property<float>("Depth");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<long>("Edition");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<string>("Features");

                    b.Property<float>("Height");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Model");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<string>("SerialNumber");

                    b.Property<float>("Shipping");

                    b.Property<string>("Source");

                    b.Property<float>("Tax");

                    b.Property<float>("UnitPrice");

                    b.Property<float>("Weight");

                    b.Property<float>("Width");

                    b.HasKey("ID");

                    b.HasIndex("AssignmentID");

                    b.HasIndex("BinID");

                    b.ToTable("Item");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("InventoriumLib.Location", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Addr1");

                    b.Property<string>("Addr2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<long>("Edition");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("ID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("InventoriumLib.PartsBin", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<long>("Edition");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<Guid?>("RackID");

                    b.Property<int>("RackIndexX");

                    b.Property<int>("RackIndexY");

                    b.Property<int>("RackIndexZ");

                    b.HasKey("ID");

                    b.HasIndex("RackID");

                    b.ToTable("PartsBin");
                });

            modelBuilder.Entity("InventoriumLib.Project", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<long>("Edition");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerID");

                    b.Property<DateTime>("TargetDate");

                    b.HasKey("ID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("InventoriumLib.OBC", b =>
                {
                    b.HasBaseType("InventoriumLib.Item");

                    b.Property<int>("AnalogPinCount");

                    b.Property<bool>("BLE");

                    b.Property<bool>("Bluetooth");

                    b.Property<string>("CPU");

                    b.Property<float>("FlashMemory");

                    b.Property<int>("GPIOCount");

                    b.Property<float>("MaxSourceAmps");

                    b.Property<bool>("Out3_3V");

                    b.Property<bool>("Out5V");

                    b.Property<int>("PWMPinCount");

                    b.Property<string>("Platform");

                    b.Property<bool>("PowerJack");

                    b.Property<float>("RAM");

                    b.Property<bool>("ResetButton");

                    b.Property<int>("USBConnectorCount");

                    b.Property<bool>("USBPower");

                    b.Property<float>("Voltage");

                    b.Property<bool>("Wifi");

                    b.ToTable("OBC");

                    b.HasDiscriminator().HasValue("OBC");
                });

            modelBuilder.Entity("InventoriumLib.Application", b =>
                {
                    b.HasOne("InventoriumLib.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID");
                });

            modelBuilder.Entity("InventoriumLib.BinRack", b =>
                {
                    b.HasOne("InventoriumLib.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");
                });

            modelBuilder.Entity("InventoriumLib.Item", b =>
                {
                    b.HasOne("InventoriumLib.Application", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentID");

                    b.HasOne("InventoriumLib.PartsBin", "Bin")
                        .WithMany()
                        .HasForeignKey("BinID");
                });

            modelBuilder.Entity("InventoriumLib.PartsBin", b =>
                {
                    b.HasOne("InventoriumLib.BinRack", "Rack")
                        .WithMany()
                        .HasForeignKey("RackID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
