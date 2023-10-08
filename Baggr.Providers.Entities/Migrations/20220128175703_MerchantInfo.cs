using Microsoft.EntityFrameworkCore.Migrations;

namespace Baggr.Providers.Entities.Migrations
{
    public partial class MerchantInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MerchantAddress",
                table: "Shipments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantCity",
                table: "Shipments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantCompanyName",
                table: "Shipments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantEmail",
                table: "Shipments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantName",
                table: "Shipments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantPhoneNum",
                table: "Shipments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
