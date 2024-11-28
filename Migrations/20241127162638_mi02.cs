using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BatDongSan.Migrations
{
    /// <inheritdoc />
    public partial class mi02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "DateUp", "Detail", "Hide", "ImagePath", "Link", "Meta", "Order", "Title" },
                values: new object[,]
                {
                    { 1, "Celebrate the grand opening of Lạc Long Quân Tower, the new landmark in Hà Nội.", new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(991), "Lạc Long Quân Tower offers luxury apartments with premium amenities for a modern lifestyle.", false, "/images/news/laclongquan-tower.jpg", "/news/laclongquan-tower-opening", "-1", 1, "Grand Opening of Lạc Long Quân Tower" },
                    { 2, "Discover the perfect blend of nature and modern living at Green Home Hà Nội.", new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(995), "Green Home Hà Nội features lush gardens, eco-friendly designs, and convenient facilities.", false, "/images/news/green-home.jpg", "/news/green-home-hanoi", "-2", 2, "Green Living in the Heart of Hà Nội" },
                    { 3, "Experience unparalleled luxury at the newly launched apartments in the city center.", new DateTime(2024, 11, 27, 23, 26, 37, 820, DateTimeKind.Local).AddTicks(997), "Our new apartments redefine elegance with state-of-the-art designs and facilities.", true, "/images/news/luxury-apartments.jpg", "/news/luxury-apartments", "-3", 3, "Luxury Apartments Now Available" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 27, 23, 26, 37, 825, DateTimeKind.Local).AddTicks(3288), "d0nWdZT7RBzOZ3n40yMqiA==:um9ZgiBEaF6lLJksPSKf47XZWs8cxEkubL9R1PabImA=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 23, 35, 842, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "ChildMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 23, 35, 842, DateTimeKind.Local).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 23, 35, 842, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 23, 35, 842, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 23, 35, 842, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateBegin",
                value: new DateTime(2024, 11, 27, 23, 23, 35, 842, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 11, 27, 23, 23, 35, 847, DateTimeKind.Local).AddTicks(7277), "ZQhOrqEqDznTdjF1zrAH9Q==:UOj2p5PuziyiH4BjAf8+IkuN7SJm/AmUcfPOSnIRhlw=" });
        }
    }
}
