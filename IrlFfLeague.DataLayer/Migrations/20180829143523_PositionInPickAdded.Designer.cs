﻿// <auto-generated />
using System;
using IrlFfLeague.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IrlFfLeague.DataLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180829143523_PositionInPickAdded")]
    partial class PositionInPickAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IrlFfLeague.Core.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("League");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("IrlFfLeague.Core.Models.Pick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Matchday");

                    b.Property<int>("PlayerId");

                    b.Property<int>("Scheme");

                    b.HasKey("Id");

                    b.ToTable("Picks");
                });

            modelBuilder.Entity("IrlFfLeague.Core.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClubId");

                    b.Property<int?>("FirstPosition");

                    b.Property<bool>("IsInjured");

                    b.Property<string>("Link");

                    b.Property<int>("MainPosition");

                    b.Property<string>("Name");

                    b.Property<int?>("SecondPosition");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("UserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("IrlFfLeague.Core.Models.PlayerInPick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GoalPasses");

                    b.Property<int>("Goals");

                    b.Property<bool>("MVP");

                    b.Property<int>("Minutes");

                    b.Property<int>("MissedGoals");

                    b.Property<int>("NotScoredPenalties");

                    b.Property<int>("OwnGoals");

                    b.Property<int>("PickId");

                    b.Property<int>("PlayerId");

                    b.Property<int>("Position");

                    b.Property<int>("RedCards");

                    b.Property<int>("TakenPenalties");

                    b.Property<int>("YellowCards");

                    b.HasKey("Id");

                    b.HasIndex("PickId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerInPicks");
                });

            modelBuilder.Entity("IrlFfLeague.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, Name = "Герберт" },
                        new { Id = 2, Name = "Роман" },
                        new { Id = 3, Name = "Артём" },
                        new { Id = 4, Name = "Владимир" },
                        new { Id = 5, Name = "Виктор" }
                    );
                });

            modelBuilder.Entity("IrlFfLeague.Core.Models.Player", b =>
                {
                    b.HasOne("IrlFfLeague.Core.Models.Club", "Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IrlFfLeague.Core.Models.User", "User")
                        .WithMany("Players")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IrlFfLeague.Core.Models.PlayerInPick", b =>
                {
                    b.HasOne("IrlFfLeague.Core.Models.Pick", "Pick")
                        .WithMany("PlayerInPicks")
                        .HasForeignKey("PickId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IrlFfLeague.Core.Models.Player", "Player")
                        .WithMany("PlayerInPicks")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
