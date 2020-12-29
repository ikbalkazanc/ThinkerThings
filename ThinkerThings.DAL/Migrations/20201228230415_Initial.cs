using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ThinkerThings.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SSID = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    NetworkId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Networks_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Networks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirConditioners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isOpen = table.Column<bool>(type: "boolean", nullable: false),
                    Tempature = table.Column<int>(type: "integer", nullable: false),
                    FanSpeed = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirConditioners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirConditioners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotionSensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isAnyMotion = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotionSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotionSensors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmartLamp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isOpen = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartLamp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartLamp_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotionDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MotionSensorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotionDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotionDates_MotionSensors_MotionSensorId",
                        column: x => x.MotionSensorId,
                        principalTable: "MotionSensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Networks",
                columns: new[] { "Id", "Password", "SSID" },
                values: new object[] { 1, "123", "Network" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Mail", "Name", "NetworkId", "Password", "Surname" },
                values: new object[] { 1, "ikbalkazanc", "ikbal", 1, "123", "Kazancı" });

            migrationBuilder.InsertData(
                table: "AirConditioners",
                columns: new[] { "Id", "FanSpeed", "Tempature", "UserId", "isOpen" },
                values: new object[] { 1, 0, 0, 1, false });

            migrationBuilder.InsertData(
                table: "MotionSensors",
                columns: new[] { "Id", "UserId", "isAnyMotion" },
                values: new object[] { 1, 1, false });

            migrationBuilder.InsertData(
                table: "SmartLamp",
                columns: new[] { "Id", "UserId", "isOpen" },
                values: new object[] { 1, 1, false });

            migrationBuilder.InsertData(
                table: "MotionDates",
                columns: new[] { "Id", "Date", "MotionSensorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 29, 2, 4, 14, 610, DateTimeKind.Local).AddTicks(3168), 1 },
                    { 2, new DateTime(2020, 12, 29, 2, 4, 14, 611, DateTimeKind.Local).AddTicks(5971), 1 },
                    { 3, new DateTime(2020, 12, 29, 2, 4, 14, 611, DateTimeKind.Local).AddTicks(5987), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirConditioners_UserId",
                table: "AirConditioners",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MotionDates_MotionSensorId",
                table: "MotionDates",
                column: "MotionSensorId");

            migrationBuilder.CreateIndex(
                name: "IX_MotionSensors_UserId",
                table: "MotionSensors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartLamp_UserId",
                table: "SmartLamp",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NetworkId",
                table: "Users",
                column: "NetworkId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirConditioners");

            migrationBuilder.DropTable(
                name: "MotionDates");

            migrationBuilder.DropTable(
                name: "SmartLamp");

            migrationBuilder.DropTable(
                name: "MotionSensors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Networks");
        }
    }
}
