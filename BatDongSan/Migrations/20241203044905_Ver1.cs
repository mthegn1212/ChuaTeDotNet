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
            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateBegin",
                value: new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateBegin", "Link", "Meta", "Name" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9121), "/PostProject", "post-project", "PostProject" });

            migrationBuilder.InsertData(
                table: "MenuItem",
                columns: new[] { "Id", "DateBegin", "Hide", "Link", "Meta", "Name", "Order" },
                values: new object[] { 5, new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9123), false, "/ProjectManagement", "project-management", "Project Management", 5 });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateUp",
                value: new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateUp",
                value: new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateUp",
                value: new DateTime(2024, 12, 3, 11, 49, 3, 882, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 3, 11, 49, 3, 888, DateTimeKind.Local).AddTicks(4836), "WbYNJET91kmcPuAeBTB/aQ==:VL2VW9ZvB0Q8QiBAHOAs8QaTGyWjyJmNSBClmX6KuLU=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateBegin",
                value: new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateBegin", "Link", "Meta", "Name" },
                values: new object[] { new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8803), "/PostNew", "Post-New", "PostNew" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateUp",
                value: new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateUp",
                value: new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateUp",
                value: new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 12, 2, 23, 12, 11, 661, DateTimeKind.Local).AddTicks(2193), "on7x5jB+jd1ddFCSLNHLqg==:aOddgGWTfHgVXNFggMH7fYNWgx81ODZcJkk8CFgGH0k=" });
        }
    }
}
