using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BatDongSan.Migrations
{
    /// <inheritdoc />
    public partial class p01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ChildMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildMenus_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItem",
                columns: new[] { "Id", "DateBegin", "Hide", "Link", "Meta", "Name", "Order" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 28, 16, 31, 21, 11, DateTimeKind.Local).AddTicks(6970), false, "/", "home", "Home", 1 },
                    { 2, new DateTime(2024, 10, 28, 16, 31, 21, 11, DateTimeKind.Local).AddTicks(6982), false, "/listing", "listing", "Listing", 2 },
                    { 3, new DateTime(2024, 10, 28, 16, 31, 21, 11, DateTimeKind.Local).AddTicks(6984), false, "/news", "news", "News", 3 },
                    { 4, new DateTime(2024, 10, 28, 16, 31, 21, 11, DateTimeKind.Local).AddTicks(6985), false, "/PostNew", "Post-New", "PostNew", 4 }
                });

            migrationBuilder.InsertData(
                table: "ChildMenus",
                columns: new[] { "Id", "DateBegin", "Hide", "Link", "MenuItemId", "Meta", "Name", "Order" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 28, 16, 31, 21, 11, DateTimeKind.Local).AddTicks(7072), false, "/RentListing", 2, "rentlisting", "RentListing", 1 },
                    { 2, new DateTime(2024, 10, 28, 16, 31, 21, 11, DateTimeKind.Local).AddTicks(7074), false, "/SaleListing", 2, "salelisting", "SaleListing", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildMenus_MenuItemId",
                table: "ChildMenus",
                column: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildMenus");

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Projects");
        }
    }
}
