using Microsoft.EntityFrameworkCore.Migrations;

namespace Baggr.Providers.Entities.Migrations
{
    public partial class Alter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "JTExpressCities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "JTExpressCities",
                type: "int",
                nullable: true);
        }
    }
}
