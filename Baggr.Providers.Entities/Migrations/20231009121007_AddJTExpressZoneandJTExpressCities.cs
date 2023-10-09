using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Baggr.Providers.Entities.Migrations
{
    public partial class AddJTExpressZoneandJTExpressCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JTExpressZones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PriceChangeRatio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JTExpressZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JTExpressCities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    ZoneId = table.Column<int>(nullable: true),
                    JTExpressZoneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JTExpressCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JTExpressCities_JTExpressZones_JTExpressZoneId",
                        column: x => x.JTExpressZoneId,
                        principalTable: "JTExpressZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JTExpressCities_JTExpressZoneId",
                table: "JTExpressCities",
                column: "JTExpressZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JTExpressCities");

            migrationBuilder.DropTable(
                name: "JTExpressZones");
        }
    }
}
