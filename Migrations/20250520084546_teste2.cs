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
            migrationBuilder.DropForeignKey(
                name: "FK_Fotografias_Media_MediaFK",
                table: "Fotografias");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Media_MediaFK",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Autores_AutorFk",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Generos_GeneroFk",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_TipoMedias_TipoMediaFk",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Media_MediaFK",
                table: "Musicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Medias");

            migrationBuilder.RenameIndex(
                name: "IX_Media_TipoMediaFk",
                table: "Medias",
                newName: "IX_Medias_TipoMediaFk");

            migrationBuilder.RenameIndex(
                name: "IX_Media_GeneroFk",
                table: "Medias",
                newName: "IX_Medias_GeneroFk");

            migrationBuilder.RenameIndex(
                name: "IX_Media_AutorFk",
                table: "Medias",
                newName: "IX_Medias_AutorFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotografias_Medias_MediaFK",
                table: "Fotografias",
                column: "MediaFK",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Medias_MediaFK",
                table: "Likes",
                column: "MediaFK",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Autores_AutorFk",
                table: "Medias",
                column: "AutorFk",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Generos_GeneroFk",
                table: "Medias",
                column: "GeneroFk",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_TipoMedias_TipoMediaFk",
                table: "Medias",
                column: "TipoMediaFk",
                principalTable: "TipoMedias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Medias_MediaFK",
                table: "Musicas",
                column: "MediaFK",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotografias_Medias_MediaFK",
                table: "Fotografias");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Medias_MediaFK",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Autores_AutorFk",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Generos_GeneroFk",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_TipoMedias_TipoMediaFk",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Medias_MediaFK",
                table: "Musicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "Media");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_TipoMediaFk",
                table: "Media",
                newName: "IX_Media_TipoMediaFk");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_GeneroFk",
                table: "Media",
                newName: "IX_Media_GeneroFk");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_AutorFk",
                table: "Media",
                newName: "IX_Media_AutorFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotografias_Media_MediaFK",
                table: "Fotografias",
                column: "MediaFK",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Media_MediaFK",
                table: "Likes",
                column: "MediaFK",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Autores_AutorFk",
                table: "Media",
                column: "AutorFk",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Generos_GeneroFk",
                table: "Media",
                column: "GeneroFk",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_TipoMedias_TipoMediaFk",
                table: "Media",
                column: "TipoMediaFk",
                principalTable: "TipoMedias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Media_MediaFK",
                table: "Musicas",
                column: "MediaFK",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
