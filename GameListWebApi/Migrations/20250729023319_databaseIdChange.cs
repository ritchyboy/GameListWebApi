using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameListWebApi.Migrations
{
    /// <inheritdoc />
    public partial class databaseIdChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "games",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Adventure game extremely hard full of challenge", "Elden Ring" },
                    { 2, "Beautiful game with a rich story", "Stellar blade" },
                    { 3, "Adventure game and puzzle", "The Legend Of Zelda" },
                    { 4, "Game of robot trying to be humain", "Nier Automata" },
                    { 5, "Mecha game action and fight", "Armored Core V" },
                    { 6, "Game of war shooting game", "Battlefield 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "games");
        }
    }
}
