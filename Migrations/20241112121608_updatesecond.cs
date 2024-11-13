using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Systemlibrary.Migrations
{
    /// <inheritdoc />
    public partial class updatesecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_admins",
                table: "admins");

            migrationBuilder.RenameTable(
                name: "admins",
                newName: "admings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admings",
                table: "admings",
                column: "adminid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_admings",
                table: "admings");

            migrationBuilder.RenameTable(
                name: "admings",
                newName: "admins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admins",
                table: "admins",
                column: "adminid");
        }
    }
}
