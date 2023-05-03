using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manero_backend.Migrations
{
    /// <inheritdoc />
    public partial class test123user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee8dde6-b8f2-4c07-b193-ff36e70eb6a2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2cfb7fc3-1965-4e0a-9889-48851538dabd", "d433e00c-8e48-406e-afa2-55edec15e7e4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cfb7fc3-1965-4e0a-9889-48851538dabd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d433e00c-8e48-406e-afa2-55edec15e7e4");

            migrationBuilder.AddColumn<string>(
                name: "AdressDefinition",
                table: "AspNetUserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdressDefinition",
                table: "AspNetUserAddresses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cfb7fc3-1965-4e0a-9889-48851538dabd", "d23b1c57-8e3b-4a65-aa37-abc09611b7c8", "admin", "Admin" },
                    { "6ee8dde6-b8f2-4c07-b193-ff36e70eb6a2", "42b26a1c-a03c-4367-85e1-14cf7edfe433", "user", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConfirmPassword", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d433e00c-8e48-406e-afa2-55edec15e7e4", 0, "a5c6dec6-29ee-4366-8d64-8d32090c56f7", null, "administrator@domain.com", false, false, null, null, null, null, null, "AQAAAAIAAYagAAAAEEFzpn2RZrh9Nim8Bpo3oJEAfRnILTLf/Kna0YBXqup/KpMp+abuGBG2UdF/xzg9VA==", null, false, "fc6cc7b9-926b-4be4-aaa8-52f197760b27", false, "administrator@domain.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2cfb7fc3-1965-4e0a-9889-48851538dabd", "d433e00c-8e48-406e-afa2-55edec15e7e4" });
        }
    }
}
