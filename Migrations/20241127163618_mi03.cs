using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatDongSan.Migrations
{
    /// <inheritdoc />
    public partial class mi03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Projects",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Area",
                table: "Projects",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 36, 17, 558, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 36, 17, 558, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 36, 17, 558, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 36, 17, 558, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 36, 17, 558, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 36, 17, 558, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateUp",
                value: new DateTime(2024, 11, 27, 23, 36, 17, 558, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateUp",
                value: new DateTime(2024, 11, 27, 23, 36, 17, 558, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateUp",
                value: new DateTime(2024, 11, 27, 23, 36, 17, 558, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 27, 23, 36, 17, 563, DateTimeKind.Local).AddTicks(6555), "6NWLltbADmIVgkckJwbIug==:W8FcXk/utsoNUgn0zpmT4AUNeeNe+s/OMOx/VbIC8kA=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(971));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateUp",
                value: new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateUp",
                value: new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateUp",
                value: new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(997));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 27, 23, 26, 37, 825, DateTimeKind.Local).AddTicks(3288), "d0nWdZT7RBzOZ3n40yMqiA==:um9ZgiBEaF6lLJksPSKf47XZWs8cxEkubL9R1PabImA=" });
        }
    }
}
