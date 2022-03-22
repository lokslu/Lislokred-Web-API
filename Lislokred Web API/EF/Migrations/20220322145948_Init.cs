using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lislokred_Web_API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmingUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmingUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImdbAverageRating = table.Column<double>(type: "float", nullable: false),
                    ImdbNumVotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    IsAnotherSource = table.Column<bool>(type: "bit", nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUnit_FilmingUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "FilmingUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageMovies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    IsAnotherSource = table.Column<bool>(type: "bit", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieToGenre",
                columns: table => new
                {
                    GanreId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieToGenre", x => new { x.MovieId, x.GanreId });
                    table.ForeignKey(
                        name: "FK_MovieToGenre_Genres_GanreId",
                        column: x => x.GanreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieToGenre_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratio",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Актёр"),
                    Сharacter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orderig = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratio", x => new { x.MovieId, x.FilmUnitId });
                    table.ForeignKey(
                        name: "FK_Ratio_FilmingUnits_FilmUnitId",
                        column: x => x.FilmUnitId,
                        principalTable: "FilmingUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratio_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    IsAnotherSource = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateAndRate",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Rate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateAndRate", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_StateAndRate_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateAndRate_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToGenre",
                columns: table => new
                {
                    GanreId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToGenre", x => new { x.UserId, x.GanreId });
                    table.ForeignKey(
                        name: "FK_UserToGenre_Genres_GanreId",
                        column: x => x.GanreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToGenre_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageMovies_Id",
                table: "ImageMovies",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageMovies_MovieId",
                table: "ImageMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUnit_Id",
                table: "ImageUnit",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageUnit_UnitId",
                table: "ImageUnit",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUser_Id",
                table: "ImageUser",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageUser_UserId",
                table: "ImageUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Id",
                table: "Movies",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ImdbId",
                table: "Movies",
                column: "ImdbId",
                unique: true,
                filter: "[ImdbId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovieToGenre_GanreId",
                table: "MovieToGenre",
                column: "GanreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieToGenre_MovieId_GanreId",
                table: "MovieToGenre",
                columns: new[] { "MovieId", "GanreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratio_FilmUnitId",
                table: "Ratio",
                column: "FilmUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratio_MovieId_FilmUnitId",
                table: "Ratio",
                columns: new[] { "MovieId", "FilmUnitId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StateAndRate_MovieId_UserId",
                table: "StateAndRate",
                columns: new[] { "MovieId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StateAndRate_UserId",
                table: "StateAndRate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToGenre_GanreId",
                table: "UserToGenre",
                column: "GanreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToGenre_UserId_GanreId",
                table: "UserToGenre",
                columns: new[] { "UserId", "GanreId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageMovies");

            migrationBuilder.DropTable(
                name: "ImageUnit");

            migrationBuilder.DropTable(
                name: "ImageUser");

            migrationBuilder.DropTable(
                name: "MovieToGenre");

            migrationBuilder.DropTable(
                name: "Ratio");

            migrationBuilder.DropTable(
                name: "StateAndRate");

            migrationBuilder.DropTable(
                name: "UserToGenre");

            migrationBuilder.DropTable(
                name: "FilmingUnits");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
