using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movie_Characters_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "franchises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_franchises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharactersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "characters",
                columns: new[] { "Id", "Alias", "Gender", "Name", "PictureUrl" },
                values: new object[,]
                {
                    { 1, "Iron Man", "Man", "Anthony Edward", "https://s3-us-west-2.amazonaws.com/forgefiction/wiki-pages-photos-test/image_anthony-edward-tony-stark-29WfBUfull.jpeg?hash=1588261380-344802" },
                    { 2, "The Hulk", "Man", "Robert Bruce Banner", "https://static.wikia.nocookie.net/transformerstopmotion/images/3/37/Bruce_Banner_Hulk_Avengers.png/revision/latest?cb=20140306034833" },
                    { 3, "Frodo Bagger", "Man", "Elijah Wood", "https://m.media-amazon.com/images/M/MV5BMTM0NDIxMzQ5OF5BMl5BanBnXkFtZTcwNzAyNTA4Nw@@._V1_.jpg" }
                });

            migrationBuilder.InsertData(
                table: "franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The Marvel Cinematic Universe contains 23 movies", "Marvel" },
                    { 2, "Contains both the good trilogy and that other Hobbit one", "The Lord of the Rings" }
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "PictureUrl", "Title", "TrailerUrl", "Year" },
                values: new object[,]
                {
                    { 1, "James Gunn", 1, "Action, Fantasia", "https://m.media-amazon.com/images/M/MV5BMDgxOTdjMzYtZGQxMS00ZTAzLWI4Y2UtMTQzN2VlYjYyZWRiXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX1000_.jpg", "Guardians of the Galaxy Vol 3 ", "https://youtu.be/u3V5KDHRQvk", 2023 },
                    { 2, "Ryan Coogler", 1, "Action , Fantasia", "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/E9C4697F1745DEF68CD73B638BE6FCFB72B537788FB4F252E04B7BB745EE27A9/scale?width=1200&aspectRatio=1.78&format=jpeg", "Black Panther", "https://youtu.be/xjDjIWPwcPU", 2022 },
                    { 3, "Peter Jackson", 2, "Drama", "https://static.tvtropes.org/pmwiki/pub/images/868ad3d2_3a50_4a2a_8218_4fa10d1352b0.jpeg", "The Hobbit: An Unexpected Journey", "https://youtu.be/SDnYMbYB-nU", 2012 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MoviesId",
                table: "CharacterMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_FranchiseId",
                table: "movies",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "franchises");
        }
    }
}
