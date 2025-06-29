using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDevWeb_V2.Migrations
{
    /// <inheritdoc />
    public partial class abc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "922b13d4-21c9-4298-9e60-811c1a3abaa5", "AQAAAAIAAYagAAAAEO7MeQlaUn/txE7nuPM1Z1YiGSilkPLx0H/qDeB2M/zFeIE4Bm1SM/advn6hl7kSvw==", "d03264e3-8432-4a1f-985e-ede8aa19f42e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c9ff3d4-655a-4543-be53-519accdd95a1", "AQAAAAIAAYagAAAAEK0SgIT10Tq5Y6gNUNUyemkAuddki4Avx3iCh3r97psmT7LskMxtAZLXH0+5IQzTmQ==", "20516609-4bb7-42b1-a3b7-bc49fd57eb50" });
        }
    }
}
