using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindWorkApp.Migrations
{
    public partial class addAgeResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "JobResumes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "JobResumes");
        }
    }
}
