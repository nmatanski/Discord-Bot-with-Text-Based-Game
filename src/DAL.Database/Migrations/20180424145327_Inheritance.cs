using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Database.Migrations
{
    public partial class Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToHeal",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountToHeal",
                table: "Items",
                nullable: true);
        }
    }
}
