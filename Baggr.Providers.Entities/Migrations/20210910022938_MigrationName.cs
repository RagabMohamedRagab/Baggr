using Microsoft.EntityFrameworkCore.Migrations;

namespace Baggr.Providers.Entities.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                table: "ProviderCities");

            migrationBuilder.AddColumn<string>(
                name: "MappedName",
                table: "ProviderCities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MappedName",
                table: "ProviderCities");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "ProviderCities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
