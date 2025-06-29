using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDevWeb_V2.Migrations
{
    /// <inheritdoc />
    public partial class teste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c71da0ad-c1ca-4a6c-a28d-9164de95ebde", "AQAAAAIAAYagAAAAED8n3j8Kvm+Wwia0ZPlcICNB5IDPVhiTk3qsXTdrpTD0v9IhfCA3EyJqA+BBNXGhPw==", "cef56dca-1546-46a0-a4a1-65f719bd5fd2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53a0ac4d-2001-466d-8ed9-320b8d5ebc7e", "AQAAAAIAAYagAAAAEL9BtW+jn6rM9+ROmDmc++Wepftp5d2ErtYIeQeIZKecpkUZP+anXe/Vpm2esRk0Xg==", "06812467-1e0e-4fde-a6e5-66ad6d27fb5c" });
        }
    }
}
