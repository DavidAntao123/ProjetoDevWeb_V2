using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDevWeb_V2.Migrations
{
    /// <inheritdoc />
    public partial class teste4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35689903-946f-47bb-990a-0fc77cf3a8a3", "AQAAAAIAAYagAAAAEN8gOe0Jm3p43BGrnHeleocapZFv2cUN+LHhFwMX8WTEWemGq4lB9+0plDia/jFbuQ==", "cb1948c7-dc8a-4cff-bb5e-53dd7bf12b43" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8874fb17-394f-49ce-a4e9-19853a9ae38f", "AQAAAAIAAYagAAAAEOtdXW8AythxqZlw4sF1leVpVPiamJ71nnae45/akXy3jIs2tJrrZlbfGmKN80ls0w==", "b061e84a-044b-4f5e-bb85-28bd8e9dac07" });
        }
    }
}
