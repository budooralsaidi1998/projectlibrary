using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Systemlibrary.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    adminid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_password = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.adminid);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    number_categery = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RGender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    borrowcopies = table.Column<int>(type: "int", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    copies_number = table.Column<int>(type: "int", nullable: false),
                    price_book = table.Column<double>(type: "float", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookid);
                    table.ForeignKey(
                        name: "FK_Books_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "borrowings",
                columns: table => new
                {
                    borrow_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    bookid = table.Column<int>(type: "int", nullable: false),
                    return_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actual_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    isreturn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrowings", x => new { x.userid, x.bookid, x.borrow_date });
                    table.ForeignKey(
                        name: "FK_borrowings_Books_bookid",
                        column: x => x.bookid,
                        principalTable: "Books",
                        principalColumn: "bookid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_borrowings_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_categoryid",
                table: "Books",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_borrowings_bookid",
                table: "borrowings",
                column: "bookid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "borrowings");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
