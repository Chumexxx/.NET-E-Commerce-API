using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class IsCancelledCancelDateToOrderModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CancelDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Order");

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
    }
}
