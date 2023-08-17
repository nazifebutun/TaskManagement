using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Personnels");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Personnels",
                newName: "NameSurname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "Personnels",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Personnels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
