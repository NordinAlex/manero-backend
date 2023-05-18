using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero_backend.Migrations.Identity
{
    /// <inheritdoc />
    public partial class ChangedUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressEntityId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Issuer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Issuer",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AddressEntityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressEntityId",
                table: "AspNetUsers",
                column: "AddressEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressEntityId",
                table: "AspNetUsers",
                column: "AddressEntityId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
