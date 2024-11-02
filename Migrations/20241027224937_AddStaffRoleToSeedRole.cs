using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddStaffRoleToSeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d166c17-6af9-4671-8fd5-afd243fb3c1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "670f9899-1052-41c5-8e0d-3db5afbe3d96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fba9ae43-9576-44a0-b6b2-d1a5ff9632db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "527a0aff-ae48-400b-8b12-971c0267a17b", null, "Staff", "STAFF" },
                    { "54ebd166-18d9-41ba-8811-d70b68e85e19", null, "SuperAdmin", "SUPERADMIN" },
                    { "c009747c-6f9c-40c3-985c-038dae58b46c", null, "Customer", "CUSTOMER" },
                    { "edf3da26-0ed5-481a-a736-25c730dd4df0", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "527a0aff-ae48-400b-8b12-971c0267a17b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54ebd166-18d9-41ba-8811-d70b68e85e19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c009747c-6f9c-40c3-985c-038dae58b46c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edf3da26-0ed5-481a-a736-25c730dd4df0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d166c17-6af9-4671-8fd5-afd243fb3c1e", null, "SuperAdmin", "SUPERADMIN" },
                    { "670f9899-1052-41c5-8e0d-3db5afbe3d96", null, "Admin", "ADMIN" },
                    { "fba9ae43-9576-44a0-b6b2-d1a5ff9632db", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
