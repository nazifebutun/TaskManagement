using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class taskfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_BTPersonnel_BTPersonnelId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BTPersonnel",
                table: "BTPersonnel");

            migrationBuilder.RenameTable(
                name: "BTPersonnel",
                newName: "BTPersonnels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BTPersonnels",
                table: "BTPersonnels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_BTPersonnels_BTPersonnelId",
                table: "Services",
                column: "BTPersonnelId",
                principalTable: "BTPersonnels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_BTPersonnels_BTPersonnelId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BTPersonnels",
                table: "BTPersonnels");

            migrationBuilder.RenameTable(
                name: "BTPersonnels",
                newName: "BTPersonnel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BTPersonnel",
                table: "BTPersonnel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_BTPersonnel_BTPersonnelId",
                table: "Services",
                column: "BTPersonnelId",
                principalTable: "BTPersonnel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
