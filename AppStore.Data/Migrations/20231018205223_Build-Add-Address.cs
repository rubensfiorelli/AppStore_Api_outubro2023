using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class BuildAddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_City",
                schema: "User",
                table: "User",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_Complement",
                schema: "User",
                table: "User",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_Country",
                schema: "User",
                table: "User",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryAddress_Number",
                schema: "User",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_State",
                schema: "User",
                table: "User",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_Street",
                schema: "User",
                table: "User",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_ZipCode",
                schema: "User",
                table: "User",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_City",
                schema: "Order",
                table: "Order",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_Complement",
                schema: "Order",
                table: "Order",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_Country",
                schema: "Order",
                table: "Order",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryAddress_Number",
                schema: "Order",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_State",
                schema: "Order",
                table: "Order",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_Street",
                schema: "Order",
                table: "Order",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress_ZipCode",
                schema: "Order",
                table: "Order",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryAddress_City",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_Complement",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_Country",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_Number",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_State",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_Street",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_ZipCode",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_City",
                schema: "Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_Complement",
                schema: "Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_Country",
                schema: "Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_Number",
                schema: "Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_State",
                schema: "Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_Street",
                schema: "Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress_ZipCode",
                schema: "Order",
                table: "Order");
        }
    }
}
