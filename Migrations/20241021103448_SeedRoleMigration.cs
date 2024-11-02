using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "012bd408-bae4-40c0-b4ee-91deab3b773f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09255ca0-00e3-4a40-82af-c6e2ef24acb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2ddd588-8f15-4302-82b1-9dfa57406808");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "012bd408-bae4-40c0-b4ee-91deab3b773f", null, "Customer", "CUSTOMER" },
                    { "09255ca0-00e3-4a40-82af-c6e2ef24acb0", null, "Admin", "ADMIN" },
                    { "e2ddd588-8f15-4302-82b1-9dfa57406808", null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
