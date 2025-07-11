using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDevWeb_V2.Migrations
{
    /// <inheritdoc />
    public partial class teste6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6baa6452-79ef-4ecc-aa1a-9ab372ddc6cf", "AQAAAAIAAYagAAAAEMMZu1uUBikdIL3Sogf0h8iT0VlQ0gM0rHNy5ZWu4BOG3sRHrdo5jLdPQ1bkyceu5w==", "3eb62212-ba95-42ff-9f6e-a324d2240c06" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72f6f311-98cc-4482-9493-de0acd93ab98", "AQAAAAIAAYagAAAAEOOyfj7eSs/IOgORr1AKK/URvblYlyLlprus0eoOMQzYU+kMZADPveZPPVMXWfH4hw==", "030c6ea7-f04a-48ea-ac7d-e5b205564d00" });
        }
    }
}
