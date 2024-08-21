using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedTicketData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "City", "Color", "CreationDate", "District", "Governorate", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { 1, "Nasr City", 0, new DateTime(2024, 8, 21, 11, 46, 31, 760, DateTimeKind.Utc).AddTicks(1298), "District 1", "Cairo", "01234567890", 0 },
                    { 2, "Dokki", 0, new DateTime(2024, 8, 21, 11, 36, 31, 760, DateTimeKind.Utc).AddTicks(1308), "District 2", "Giza", "09876543210", 0 },
                    { 3, "Sidi Gaber", 0, new DateTime(2024, 8, 21, 11, 16, 31, 760, DateTimeKind.Utc).AddTicks(1309), "District 3", "Alexandria", "01112223344", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
