using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class IdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "104cbb7d-fa3f-4c65-baef-52912229449e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fde54aa-415d-494c-9dbd-8a7932dc365d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed755cf1-7a49-4b83-8c71-aabbc81da22a");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "104cbb7d-fa3f-4c65-baef-52912229449e", null, "Customer", "CUSTOMER" },
                    { "5fde54aa-415d-494c-9dbd-8a7932dc365d", null, "SuperAdmin", "SUPERADMIN" },
                    { "ed755cf1-7a49-4b83-8c71-aabbc81da22a", null, "Admin", "ADMIN" }
                });
        }
    }
}
