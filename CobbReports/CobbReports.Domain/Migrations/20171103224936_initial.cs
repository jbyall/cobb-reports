using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CobbReports.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    LoggerVersionInfo = table.Column<string>(type: "text", nullable: true),
                    MapInfo = table.Column<string>(type: "text", nullable: true),
                    VehicleInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccelPosition = table.Column<double>(type: "float8", nullable: true),
                    AmbientAirTemp = table.Column<double>(type: "float8", nullable: true),
                    BaroPressure = table.Column<double>(type: "float8", nullable: true),
                    Boost = table.Column<double>(type: "float8", nullable: true),
                    GearPosition = table.Column<int>(type: "int4", nullable: true),
                    IgnitionTiming = table.Column<double>(type: "float8", nullable: true),
                    IntakeTemp = table.Column<int>(type: "int4", nullable: true),
                    IntakeTempManifold = table.Column<int>(type: "int4", nullable: true),
                    LogInfoId = table.Column<int>(type: "int4", nullable: false),
                    ManAbsPress = table.Column<double>(type: "float8", nullable: true),
                    RPM = table.Column<int>(type: "int4", nullable: true),
                    TDBoostError = table.Column<double>(type: "float8", nullable: true),
                    TDIntegral = table.Column<double>(type: "float8", nullable: true),
                    TDProportional = table.Column<double>(type: "float8", nullable: true),
                    TargetBoost = table.Column<double>(type: "float8", nullable: true),
                    TargetBoostAbs = table.Column<double>(type: "float8", nullable: true),
                    TargetThrottle = table.Column<double>(type: "float8", nullable: true),
                    ThrottlePos = table.Column<int>(type: "int4", nullable: true),
                    Time = table.Column<double>(type: "float8", nullable: true),
                    VehicleSpeed = table.Column<int>(type: "int4", nullable: true),
                    WastegateDuty = table.Column<double>(type: "float8", nullable: true),
                    WategateMax = table.Column<double>(type: "float8", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_LogInfos_LogInfoId",
                        column: x => x.LogInfoId,
                        principalTable: "LogInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LogInfoId",
                table: "Logs",
                column: "LogInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "LogInfos");
        }
    }
}
