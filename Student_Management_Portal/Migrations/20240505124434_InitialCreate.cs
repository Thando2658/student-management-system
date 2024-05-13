using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_Portal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TblAdmin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadCSV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAdmin", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_TblAdmin_TblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "TblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblParent",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblParent", x => x.ParentId);
                    table.ForeignKey(
                        name: "FK_TblParent_TblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "TblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblStudent", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_TblStudent_TblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "TblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblAdmin_UserId",
                table: "TblAdmin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblParent_UserId",
                table: "TblParent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblStudent_UserId",
                table: "TblStudent",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAdmin");

            migrationBuilder.DropTable(
                name: "TblParent");

            migrationBuilder.DropTable(
                name: "TblStudent");

            migrationBuilder.DropTable(
                name: "TblUser");
        }
    }
}
