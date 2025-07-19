using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindWorkApp.Migrations
{
    public partial class CompanySite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfficialSite",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficialSite",
                table: "Companies");
        }
    }
}
