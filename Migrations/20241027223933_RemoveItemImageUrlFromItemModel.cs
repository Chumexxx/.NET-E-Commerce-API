using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class RemoveItemImageUrlFromItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a63bc734-556d-4b5f-94c0-79e439558e51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf916286-4664-4e4d-92d9-50c299e0b107");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff146acd-1535-468b-89fb-6ee62d55ff8e");

            migrationBuilder.DropColumn(
                name: "ItemImageUrl",
                table: "Items");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ItemImageUrl",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a63bc734-556d-4b5f-94c0-79e439558e51", null, "Admin", "ADMIN" },
                    { "bf916286-4664-4e4d-92d9-50c299e0b107", null, "SuperAdmin", "SUPERADMIN" },
                    { "ff146acd-1535-468b-89fb-6ee62d55ff8e", null, "Customer", "CUSTOMER" }
                });
        }
    }
}
