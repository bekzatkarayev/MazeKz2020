﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMaze.DbStuff;

namespace WebMaze.Migrations
{
    [DbContext(typeof(WebMazeContext))]
    partial class WebMazeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebMaze.DbStuff.Model.Adress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Bus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("BusRouteId")
                        .HasColumnType("bigint");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("WorkerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BusRouteId");

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.BusRoute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Route")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusRoute");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.BusStop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusStop");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.CitizenUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CitizenUser");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.Policeman", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Policemen");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.Violation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("BlamingPolicemanId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long?>("TypeOfViolationId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BlamingPolicemanId");

                    b.HasIndex("TypeOfViolationId");

                    b.HasIndex("UserId");

                    b.ToTable("Violations");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.ViolationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Article")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Penalty")
                        .HasColumnType("money");

                    b.Property<string>("Punishment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TermOfPunishment")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TypesOfViolation");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Bus", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.BusRoute", "BusRoute")
                        .WithMany()
                        .HasForeignKey("BusRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusRoute");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.Policeman", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.CitizenUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.Violation", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.Police.Policeman", "BlamingPoliceman")
                        .WithMany()
                        .HasForeignKey("BlamingPolicemanId");

                    b.HasOne("WebMaze.DbStuff.Model.Police.ViolationType", "TypeOfViolation")
                        .WithMany("Violations")
                        .HasForeignKey("TypeOfViolationId");

                    b.HasOne("WebMaze.DbStuff.Model.CitizenUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("BlamingPoliceman");

                    b.Navigation("TypeOfViolation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.ViolationType", b =>
                {
                    b.Navigation("Violations");
                });
#pragma warning restore 612, 618
        }
    }
}
