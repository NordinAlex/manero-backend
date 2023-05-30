using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero_backend.Migrations.Identity
{
    /// <inheritdoc />
    public partial class ChangedEntityForTagName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagName",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "UserAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagName",
                table: "UserAddress");

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
