using Microsoft.EntityFrameworkCore.Migrations;

namespace Baggr.Providers.Entities.Migrations
{
    public partial class RemoveMerchantDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MerchantAddress",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "MerchantCity",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "MerchantCompanyName",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "MerchantEmail",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "MerchantName",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "MerchantPhoneNum",
                table: "Shipments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MerchantAddress",
                table: "Shipments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantCity",
                table: "Shipments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantCompanyName",
                table: "Shipments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantEmail",
                table: "Shipments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantName",
                table: "Shipments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantPhoneNum",
                table: "Shipments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
