using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatDongSan.Migrations
{
    /// <inheritdoc />
    public partial class Ver1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Down(migrationBuilder);
            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 32, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 32, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 32, DateTimeKind.Local).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 32, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 32, DateTimeKind.Local).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateUp",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateUp",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateUp",
                value: new DateTime(2024, 12, 6, 23, 25, 50, 25, DateTimeKind.Local).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 6, 23, 25, 50, 32, DateTimeKind.Local).AddTicks(4975), "7jtRS2EgluEvRJKKas6eiQ==:6Lt97f14fD3jH+/0Q6yWDgUKe2yDu8FugSnXMGjV44c=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 769, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 769, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 769, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 769, DateTimeKind.Local).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "HeaderFooter",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreate",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 769, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateBegin",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateUp",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateUp",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateUp",
                value: new DateTime(2024, 12, 6, 23, 22, 23, 762, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 6, 23, 22, 23, 768, DateTimeKind.Local).AddTicks(8334), "3gju0FmfKvf5YvaeSTuX2g==:0eFDZmuf5Ni7Q9X68UjUsKyWsvLRD/Abgw8iWsUaxYA=" });
        }
    }
}
