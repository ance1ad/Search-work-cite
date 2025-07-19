using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindWorkApp.Migrations
{
    public partial class CompanyCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cities",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cities",
                table: "Companies");
        }
    }
}
