using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero_backend.Migrations.Identity
{
    /// <inheritdoc />
    public partial class Addedaddressesentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AddressesType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressesType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Userid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressTypeEntityId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    InActivated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressesType");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropColumn(
                name: "TagName",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
