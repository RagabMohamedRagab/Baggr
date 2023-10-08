using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Baggr.Providers.Entities.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShipmentProducts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    OrderReference = table.Column<string>(nullable: true),
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
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentProducts_OrderId",
                table: "ShipmentProducts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentProducts_Orders_OrderId",
                table: "ShipmentProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentProducts_Orders_OrderId",
                table: "ShipmentProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentProducts_OrderId",
                table: "ShipmentProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShipmentProducts");
        }
    }
}
