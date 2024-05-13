using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_Portal.Migrations
{
    public partial class StudentPortal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "TblUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "TblUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "TblUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "TblUser");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "TblUser");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "TblUser");
        }
    }
}
