using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Baggr.Providers.Entities.Migrations
{
    public partial class Shipments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    OrderReference = table.Column<string>(nullable: true),
                    AWB = table.Column<string>(nullable: true),
                    MerchantName = table.Column<string>(nullable: true),
                    MerchantCompanyName = table.Column<string>(nullable: true),
                    MerchantEmail = table.Column<string>(nullable: true),
                    MerchantPhoneNum = table.Column<string>(nullable: true),
                    MerchantAddress = table.Column<string>(nullable: true),
                    MerchantCity = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    CustomerPhoneNum = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    CustomerCity = table.Column<string>(nullable: true),
                    TotalAmountShouldBeCollected = table.Column<double>(nullable: false),
                    NumberofPeices = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    MerchantKey = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_Key",
                table: "Shipments",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_OrderReference",
                table: "Shipments",
                column: "OrderReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ProviderId",
                table: "Shipments",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
