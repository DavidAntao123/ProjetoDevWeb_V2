using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDevWeb_V2.Migrations
{
    /// <inheritdoc />
    public partial class teste1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72f6f311-98cc-4482-9493-de0acd93ab98", "AQAAAAIAAYagAAAAEOOyfj7eSs/IOgORr1AKK/URvblYlyLlprus0eoOMQzYU+kMZADPveZPPVMXWfH4hw==", "030c6ea7-f04a-48ea-ac7d-e5b205564d00" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "922b13d4-21c9-4298-9e60-811c1a3abaa5", "AQAAAAIAAYagAAAAEO7MeQlaUn/txE7nuPM1Z1YiGSilkPLx0H/qDeB2M/zFeIE4Bm1SM/advn6hl7kSvw==", "d03264e3-8432-4a1f-985e-ede8aa19f42e" });
        }
    }
}
