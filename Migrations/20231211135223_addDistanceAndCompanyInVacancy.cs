using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindWorkApp.Migrations
{
    public partial class addDistanceAndCompanyInVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyInfo",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistanceWork",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyInfo",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "DistanceWork",
                table: "Vacancies");
        }
    }
}
