﻿// <auto-generated />
using GameLogic.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameLogic.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240109080441_CreatedMonsters")]
    partial class CreatedMonsters
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmorClass")
                        .HasColumnType("integer");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("integer");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("integer");

                    b.Property<string>("Damage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("integer");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Monsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorClass = 14,
                            AttackModifier = 5,
                            AttackPerRound = 1,
                            Damage = "4d8",
                            DamageModifier = 3,
                            HitPoints = 26,
                            Name = "Archelon"
                        },
                        new
                        {
                            Id = 2,
                            ArmorClass = 16,
                            AttackModifier = 8,
                            AttackPerRound = 3,
                            Damage = "9d10",
                            DamageModifier = 9,
                            HitPoints = 94,
                            Name = "Armanit"
                        },
                        new
                        {
                            Id = 3,
                            ArmorClass = 15,
                            AttackModifier = 6,
                            AttackPerRound = 2,
                            Damage = "8d8",
                            DamageModifier = 3,
                            HitPoints = 60,
                            Name = "Demogorgon"
                        },
                        new
                        {
                            Id = 4,
                            ArmorClass = 15,
                            AttackModifier = 7,
                            AttackPerRound = 1,
                            Damage = "13d8",
                            DamageModifier = 4,
                            HitPoints = 71,
                            Name = "Mind flayer"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
