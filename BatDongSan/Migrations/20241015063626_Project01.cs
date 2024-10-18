using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatDongSan.Migrations
{
    /// <inheritdoc />
    public partial class Project01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Projects",
                newName: "locate");

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "locate",
                table: "Projects",
                newName: "Desc");
        }
    }
}
