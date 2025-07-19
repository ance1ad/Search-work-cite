using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindWorkApp.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkExpirience",
                table: "JobResumes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkExpirience",
                table: "JobResumes");
        }
    }
}
