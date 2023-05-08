using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero_backend.Migrations.Identity
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressEntityUserEntity");

            migrationBuilder.DropTable(
                name: "OrderEntity");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AddressEntityUserEntity",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntityUserEntity", x => new { x.AddressesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AddressEntityUserEntity_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressEntityUserEntity_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEntityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderEntity_AspNetUsers_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntityUserEntity_UsersId",
                table: "AddressEntityUserEntity",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_UserEntityId",
                table: "OrderEntity",
                column: "UserEntityId");
        }
    }
}
