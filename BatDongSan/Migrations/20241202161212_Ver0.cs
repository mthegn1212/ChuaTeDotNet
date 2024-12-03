using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BatDongSan.Migrations
{
    /// <inheritdoc />
    public partial class Ver0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hide = table.Column<bool>(type: "bit", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    DateUp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hide = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Locate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    upById = table.Column<int>(type: "int", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                    { 1, new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8786), false, "/", "home", "Home", 1 },
                    { 2, new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8799), false, "/listing", "listing", "Listing", 2 },
                    { 3, new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8801), false, "/news", "news", "News", 3 },
                    { 4, new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8803), false, "/PostNew", "Post-New", "PostNew", 4 }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "DateUp", "Detail", "Hide", "ImagePath", "Link", "Meta", "Order", "Title" },
                values: new object[,]
                {
                    { 1, "Celebrate the grand opening of Lạc Long Quân Tower, the new landmark in Hà Nội.", new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8934), "Lạc Long Quân Tower offers luxury apartments with premium amenities for a modern lifestyle.", false, "/images/news/laclongquan-tower.jpg", "/news/laclongquan-tower-opening", "-1", 1, "Grand Opening of Lạc Long Quân Tower" },
                    { 2, "Discover the perfect blend of nature and modern living at Green Home Hà Nội.", new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8938), "Green Home Hà Nội features lush gardens, eco-friendly designs, and convenient facilities.", false, "/images/news/green-home.jpg", "/news/green-home-hanoi", "-2", 2, "Green Living in the Heart of Hà Nội" },
                    { 3, "Experience unparalleled luxury at the newly launched apartments in the city center.", new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8942), "Our new apartments redefine elegance with state-of-the-art designs and facilities.", true, "/images/news/luxury-apartments.jpg", "/news/luxury-apartments", "-3", 3, "Luxury Apartments Now Available" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Role", "UserName" },
                values: new object[] { 1, new DateTime(2024, 12, 2, 23, 12, 11, 661, DateTimeKind.Local).AddTicks(2193), "admin@gmail.com", "on7x5jB+jd1ddFCSLNHLqg==:aOddgGWTfHgVXNFggMH7fYNWgx81ODZcJkk8CFgGH0k=", "admin", "Minh Thắng" });

            migrationBuilder.InsertData(
                table: "ChildMenus",
                columns: new[] { "Id", "DateBegin", "Hide", "Link", "MenuItemId", "Meta", "Name", "Order" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8908), false, "/RentListing", 2, "rentlisting", "RentListing", 1 },
                    { 2, new DateTime(2024, 12, 2, 23, 12, 11, 654, DateTimeKind.Local).AddTicks(8910), false, "/SaleListing", 2, "salelisting", "SaleListing", 2 }
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

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MenuItem");
        }
    }
}
