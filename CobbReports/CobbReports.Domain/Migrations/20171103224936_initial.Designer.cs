﻿// <auto-generated />
using CobbReports.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CobbReports.Domain.Migrations
{
    [DbContext(typeof(CobbDbContext))]
    [Migration("20171103224936_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("CobbReports.Domain.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("AccelPosition");

                    b.Property<double?>("AmbientAirTemp");

                    b.Property<double?>("BaroPressure");

                    b.Property<double?>("Boost");

                    b.Property<int?>("GearPosition");

                    b.Property<double?>("IgnitionTiming");

                    b.Property<int?>("IntakeTemp");

                    b.Property<int?>("IntakeTempManifold");

                    b.Property<int>("LogInfoId");

                    b.Property<double?>("ManAbsPress");

                    b.Property<int?>("RPM");

                    b.Property<double?>("TDBoostError");

                    b.Property<double?>("TDIntegral");

                    b.Property<double?>("TDProportional");

                    b.Property<double?>("TargetBoost");

                    b.Property<double?>("TargetBoostAbs");

                    b.Property<double?>("TargetThrottle");

                    b.Property<int?>("ThrottlePos");

                    b.Property<double?>("Time");

                    b.Property<int?>("VehicleSpeed");

                    b.Property<double?>("WastegateDuty");

                    b.Property<double?>("WategateMax");

                    b.HasKey("Id");

                    b.HasIndex("LogInfoId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("CobbReports.Domain.LogInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoggerVersionInfo");

                    b.Property<string>("MapInfo");

                    b.Property<string>("VehicleInfo");

                    b.HasKey("Id");

                    b.ToTable("LogInfos");
                });

            modelBuilder.Entity("CobbReports.Domain.Log", b =>
                {
                    b.HasOne("CobbReports.Domain.LogInfo", "LogInfo")
                        .WithMany("Logs")
                        .HasForeignKey("LogInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}