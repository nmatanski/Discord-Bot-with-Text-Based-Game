using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Database.Migrations
{
    public partial class Locations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationToEastID",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationToNorthID",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationToSouthID",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationToWestID",
                table: "Locations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationToEastID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationToNorthID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationToSouthID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationToWestID",
                table: "Locations");
        }
    }
}
