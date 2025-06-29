using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDevWeb_V2.Migrations
{
    /// <inheritdoc />
    public partial class teste5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c9ff3d4-655a-4543-be53-519accdd95a1", "AQAAAAIAAYagAAAAEK0SgIT10Tq5Y6gNUNUyemkAuddki4Avx3iCh3r97psmT7LskMxtAZLXH0+5IQzTmQ==", "20516609-4bb7-42b1-a3b7-bc49fd57eb50" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35689903-946f-47bb-990a-0fc77cf3a8a3", "AQAAAAIAAYagAAAAEN8gOe0Jm3p43BGrnHeleocapZFv2cUN+LHhFwMX8WTEWemGq4lB9+0plDia/jFbuQ==", "cb1948c7-dc8a-4cff-bb5e-53dd7bf12b43" });
        }
    }
}
