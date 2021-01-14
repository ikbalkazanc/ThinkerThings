using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThinkerThings.DAL.Migrations
{
    public partial class devicenewattribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAlive",
                table: "SmartLamp",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isAlive",
                table: "MotionSensors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isAlive",
                table: "AirConditioners",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "MotionDates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 1, 14, 17, 40, 47, 916, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "MotionDates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 1, 14, 17, 40, 47, 921, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "MotionDates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 1, 14, 17, 40, 47, 921, DateTimeKind.Local).AddTicks(5546));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAlive",
                table: "SmartLamp");

            migrationBuilder.DropColumn(
                name: "isAlive",
                table: "MotionSensors");

            migrationBuilder.DropColumn(
                name: "isAlive",
                table: "AirConditioners");

            migrationBuilder.UpdateData(
                table: "MotionDates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 12, 29, 2, 4, 14, 610, DateTimeKind.Local).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "MotionDates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 12, 29, 2, 4, 14, 611, DateTimeKind.Local).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "MotionDates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 12, 29, 2, 4, 14, 611, DateTimeKind.Local).AddTicks(5987));
        }
    }
}
