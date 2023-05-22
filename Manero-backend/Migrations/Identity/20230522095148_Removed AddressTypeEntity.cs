using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero_backend.Migrations.Identity
{
    /// <inheritdoc />
    public partial class RemovedAddressTypeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressesType");

            migrationBuilder.DropColumn(
                name: "AddressTypeEntityId",
                table: "UserAddress");

            migrationBuilder.AddColumn<bool>(
                name: "BillingAddress",
                table: "UserAddress",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "UserAddress");

            migrationBuilder.AddColumn<int>(
                name: "AddressTypeEntityId",
                table: "UserAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
