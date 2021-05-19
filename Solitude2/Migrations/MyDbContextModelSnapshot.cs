﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solitude2.Data;

namespace Solitude2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Solitude2.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Bonus")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerID")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("Solitude2.Models.Monster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Alive")
                        .HasColumnType("bit");

                    b.Property<string>("AttackName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("CurrentHP")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Dmg")
                        .HasColumnType("real");

                    b.Property<int?>("DropID")
                        .HasColumnType("int");

                    b.Property<float>("ExpDrop")
                        .HasColumnType("real");

                    b.Property<float>("GoldDrop")
                        .HasColumnType("real");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<float>("MaxHP")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TalentDrop")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DropID");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("Solitude2.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Alive")
                        .HasColumnType("bit");

                    b.Property<float>("AttackPower")
                        .HasColumnType("real");

                    b.Property<float>("CritBonus")
                        .HasColumnType("real");

                    b.Property<float>("CritPercent")
                        .HasColumnType("real");

                    b.Property<float>("CurrentExp")
                        .HasColumnType("real");

                    b.Property<float>("CurrentHP")
                        .HasColumnType("real");

                    b.Property<int>("CurrentLvl")
                        .HasColumnType("int");

                    b.Property<int?>("EquippedWeaponID")
                        .HasColumnType("int");

                    b.Property<float>("ExpReqForLvl")
                        .HasColumnType("real");

                    b.Property<float>("Gold")
                        .HasColumnType("real");

                    b.Property<float>("MaxHP")
                        .HasColumnType("real");

                    b.Property<int>("MaxLvl")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EquippedWeaponID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Solitude2.Models.Potion", b =>
                {
                    b.HasBaseType("Solitude2.Models.Item");

                    b.Property<int?>("PlayerID1")
                        .HasColumnType("int");

                    b.HasIndex("PlayerID1");

                    b.HasDiscriminator().HasValue("Potion");
                });

            modelBuilder.Entity("Solitude2.Models.Weapon", b =>
                {
                    b.HasBaseType("Solitude2.Models.Item");

                    b.Property<int?>("PlayerID1")
                        .HasColumnType("int")
                        .HasColumnName("Weapon_PlayerID1");

                    b.HasIndex("PlayerID1");

                    b.HasDiscriminator().HasValue("Weapon");
                });

            modelBuilder.Entity("Solitude2.Models.Item", b =>
                {
                    b.HasOne("Solitude2.Models.Player", null)
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerID");
                });

            modelBuilder.Entity("Solitude2.Models.Monster", b =>
                {
                    b.HasOne("Solitude2.Models.Item", "Drop")
                        .WithMany()
                        .HasForeignKey("DropID");

                    b.Navigation("Drop");
                });

            modelBuilder.Entity("Solitude2.Models.Player", b =>
                {
                    b.HasOne("Solitude2.Models.Weapon", "EquippedWeapon")
                        .WithMany()
                        .HasForeignKey("EquippedWeaponID");

                    b.Navigation("EquippedWeapon");
                });

            modelBuilder.Entity("Solitude2.Models.Potion", b =>
                {
                    b.HasOne("Solitude2.Models.Player", null)
                        .WithMany("Potions")
                        .HasForeignKey("PlayerID1");
                });

            modelBuilder.Entity("Solitude2.Models.Weapon", b =>
                {
                    b.HasOne("Solitude2.Models.Player", null)
                        .WithMany("Weapons")
                        .HasForeignKey("PlayerID1");
                });

            modelBuilder.Entity("Solitude2.Models.Player", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("Potions");

                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
