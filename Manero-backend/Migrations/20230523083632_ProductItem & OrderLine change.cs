using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero_backend.Migrations
{
    /// <inheritdoc />
    public partial class ProductItemOrderLinechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "OrderLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderLines");
        }
    }
}
