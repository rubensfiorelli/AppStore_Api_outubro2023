using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class BuildGeneralUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Category");

            migrationBuilder.EnsureSchema(
                name: "Order");

            migrationBuilder.EnsureSchema(
                name: "OrderLine");

            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "User");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Product",
                newSchema: "Product");

            migrationBuilder.RenameTable(
                name: "OrderLine",
                newName: "OrderLine",
                newSchema: "OrderLine");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Order",
                newSchema: "Order");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Category",
                newSchema: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "User",
                schema: "User",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "Product",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "OrderLine",
                schema: "OrderLine",
                newName: "OrderLine");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "Order",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "Category",
                newName: "Category");
        }
    }
}
