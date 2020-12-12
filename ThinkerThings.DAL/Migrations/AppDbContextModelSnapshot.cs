﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThinkerThings.DAL;

namespace ThinkerThings.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ThinkerThings.Core.Entities.Devices.AirConditioner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("FanSpeed")
                        .HasColumnType("integer");

                    b.Property<int>("GatewayId")
                        .HasColumnType("integer");

                    b.Property<int>("Tempature")
                        .HasColumnType("integer");

                    b.Property<bool>("isOpen")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("GatewayId");

                    b.ToTable("AirConditioners");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Devices.MotionSensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("GatewayId")
                        .HasColumnType("integer");

                    b.Property<bool>("isAnyMotion")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("GatewayId");

                    b.ToTable("MotionSensors");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Devices.SmartLamp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("GatewayId")
                        .HasColumnType("integer");

                    b.Property<bool>("isOpen")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("GatewayId");

                    b.ToTable("SmartLamp");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Gateway", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("DeleteRemarks")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("NetworkId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<bool>("isAlive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("NetworkId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Gateways");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.MotionDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MotionSensorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MotionSensorId");

                    b.ToTable("MotionDates");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Network", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Passsword")
                        .HasColumnType("text");

                    b.Property<string>("SSID")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Devices.AirConditioner", b =>
                {
                    b.HasOne("ThinkerThings.Core.Entities.Gateway", "Gateway")
                        .WithMany("AirConditioners")
                        .HasForeignKey("GatewayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gateway");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Devices.MotionSensor", b =>
                {
                    b.HasOne("ThinkerThings.Core.Entities.Gateway", "Gateway")
                        .WithMany("MotionSensors")
                        .HasForeignKey("GatewayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gateway");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Devices.SmartLamp", b =>
                {
                    b.HasOne("ThinkerThings.Core.Entities.Gateway", "Gateway")
                        .WithMany("SmartLamps")
                        .HasForeignKey("GatewayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gateway");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Gateway", b =>
                {
                    b.HasOne("ThinkerThings.Core.Entities.Network", "Network")
                        .WithOne("Gateway")
                        .HasForeignKey("ThinkerThings.Core.Entities.Gateway", "NetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThinkerThings.Core.Entities.User", "User")
                        .WithMany("Gateways")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Network");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.MotionDate", b =>
                {
                    b.HasOne("ThinkerThings.Core.Entities.Devices.MotionSensor", "MotionSensor")
                        .WithMany("MotionDate")
                        .HasForeignKey("MotionSensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MotionSensor");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Devices.MotionSensor", b =>
                {
                    b.Navigation("MotionDate");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Gateway", b =>
                {
                    b.Navigation("AirConditioners");

                    b.Navigation("MotionSensors");

                    b.Navigation("SmartLamps");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.Network", b =>
                {
                    b.Navigation("Gateway");
                });

            modelBuilder.Entity("ThinkerThings.Core.Entities.User", b =>
                {
                    b.Navigation("Gateways");
                });
#pragma warning restore 612, 618
        }
    }
}
