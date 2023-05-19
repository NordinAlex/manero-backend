using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero_backend.Migrations.Identity
{
    /// <inheritdoc />
    public partial class IssuerCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Issuer",
                table: "AspNetUsers",
                newName: "CreatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "AspNetUsers",
                newName: "Issuer");
        }
    }
}
