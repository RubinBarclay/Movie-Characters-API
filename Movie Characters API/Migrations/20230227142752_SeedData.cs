using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movie_Characters_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_characters_CharactersId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_movies_MoviesId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_franchises_FranchiseId",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_franchises",
                table: "franchises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_characters",
                table: "characters");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "franchises",
                newName: "Franchises");

            migrationBuilder.RenameTable(
                name: "characters",
                newName: "Characters");

            migrationBuilder.RenameIndex(
                name: "IX_movies_FranchiseId",
                table: "Movies",
                newName: "IX_Movies_FranchiseId");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "CharacterMovie",
                newName: "CharacterId");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "CharacterMovie",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovie_MoviesId",
                table: "CharacterMovie",
                newName: "IX_CharacterMovie_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Franchises",
                table: "Franchises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "Id");

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Avengers ");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Characters_CharacterId",
                table: "CharacterMovie",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_Movies_MovieId",
                table: "CharacterMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Franchises_FranchiseId",
                table: "Movies",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Characters_CharacterId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMovie_Movies_MovieId",
                table: "CharacterMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Franchises_FranchiseId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Franchises",
                table: "Franchises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.RenameTable(
                name: "Franchises",
                newName: "franchises");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "characters");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_FranchiseId",
                table: "movies",
                newName: "IX_movies_FranchiseId");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "CharacterMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "CharacterMovie",
                newName: "CharactersId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMovie_CharacterId",
                table: "CharacterMovie",
                newName: "IX_CharacterMovie_MoviesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_franchises",
                table: "franchises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_characters",
                table: "characters",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Guardians of the Galaxy Vol 3 ");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_characters_CharactersId",
                table: "CharacterMovie",
                column: "CharactersId",
                principalTable: "characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMovie_movies_MoviesId",
                table: "CharacterMovie",
                column: "MoviesId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movies_franchises_FranchiseId",
                table: "movies",
                column: "FranchiseId",
                principalTable: "franchises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
