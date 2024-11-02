using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstNameLastNameDateOfBirthHomeAddressToAppUserModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b9270fc-e314-4cd6-a91d-488469579d3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "966c52a8-c0e1-460a-b165-5363ca261f16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eedd6402-04ea-468f-80de-ee38004640a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c7bed43-09c1-4c90-be73-94e28cc16cd2", null, "Admin", "ADMIN" },
                    { "66982586-50ee-4c1b-b109-47cb01e13c3a", null, "Customer", "CUSTOMER" },
                    { "7cc09f94-555a-454c-81fa-8ca94a5efc0d", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c7bed43-09c1-4c90-be73-94e28cc16cd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66982586-50ee-4c1b-b109-47cb01e13c3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cc09f94-555a-454c-81fa-8ca94a5efc0d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b9270fc-e314-4cd6-a91d-488469579d3b", null, "Admin", "ADMIN" },
                    { "966c52a8-c0e1-460a-b165-5363ca261f16", null, "Customer", "CUSTOMER" },
                    { "eedd6402-04ea-468f-80de-ee38004640a7", null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
