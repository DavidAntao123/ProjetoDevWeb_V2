using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDevWeb_V2.Migrations
{
    /// <inheritdoc />
    public partial class teste3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Utilizadores_UserFK",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizadores",
                table: "Utilizadores");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserName",
                table: "Utilizadores",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Utilizadores",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "UserFK",
                table: "Likes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizadores",
                table: "Utilizadores",
                column: "IdentityUserName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8874fb17-394f-49ce-a4e9-19853a9ae38f", "AQAAAAIAAYagAAAAEOtdXW8AythxqZlw4sF1leVpVPiamJ71nnae45/akXy3jIs2tJrrZlbfGmKN80ls0w==", "b061e84a-044b-4f5e-bb85-28bd8e9dac07" });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Utilizadores_UserFK",
                table: "Likes",
                column: "UserFK",
                principalTable: "Utilizadores",
                principalColumn: "IdentityUserName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Utilizadores_UserFK",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizadores",
                table: "Utilizadores");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Utilizadores",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserName",
                table: "Utilizadores",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "UserFK",
                table: "Likes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizadores",
                table: "Utilizadores",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c71da0ad-c1ca-4a6c-a28d-9164de95ebde", "AQAAAAIAAYagAAAAED8n3j8Kvm+Wwia0ZPlcICNB5IDPVhiTk3qsXTdrpTD0v9IhfCA3EyJqA+BBNXGhPw==", "cef56dca-1546-46a0-a4a1-65f719bd5fd2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Utilizadores_UserFK",
                table: "Likes",
                column: "UserFK",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
