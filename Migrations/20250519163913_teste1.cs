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
            migrationBuilder.DropForeignKey(
                name: "FK_Fotografias_Media_MediaId",
                table: "Fotografias");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "Fotografias",
                newName: "MediaFK");

            migrationBuilder.RenameIndex(
                name: "IX_Fotografias_MediaId",
                table: "Fotografias",
                newName: "IX_Fotografias_MediaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotografias_Media_MediaFK",
                table: "Fotografias",
                column: "MediaFK",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotografias_Media_MediaFK",
                table: "Fotografias");

            migrationBuilder.RenameColumn(
                name: "MediaFK",
                table: "Fotografias",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_Fotografias_MediaFK",
                table: "Fotografias",
                newName: "IX_Fotografias_MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotografias_Media_MediaId",
                table: "Fotografias",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
