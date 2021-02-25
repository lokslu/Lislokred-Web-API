using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lislokred_Web_API.Migrations
{
    public partial class DeleteMainNavigatePropertyInMainEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_FilmingUnits_FilmUnitId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Movies_MovieId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_StatesAndRates_Movies_MovieId",
                table: "StatesAndRates");

            migrationBuilder.DropForeignKey(
                name: "FK_StatesAndRates_Users_UserId",
                table: "StatesAndRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToGenre",
                table: "UserToGenre");

            migrationBuilder.DropIndex(
                name: "IX_UserToGenre_UserId",
                table: "UserToGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieToGenre",
                table: "MovieToGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieToGenre_MovieId",
                table: "MovieToGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatesAndRates",
                table: "StatesAndRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "UserToGenre");

            migrationBuilder.RenameTable(
                name: "StatesAndRates",
                newName: "StateAndRate");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Ratio");

            migrationBuilder.RenameIndex(
                name: "IX_StatesAndRates_UserId",
                table: "StateAndRate",
                newName: "IX_StateAndRate_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_FilmUnitId",
                table: "Ratio",
                newName: "IX_Ratio_FilmUnitId");

            migrationBuilder.AddColumn<Guid>(
                name: "FilmingUnitId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "StateAndRate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Ratio",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Актёр",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Actor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToGenre",
                table: "UserToGenre",
                columns: new[] { "UserId", "GanreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieToGenre",
                table: "MovieToGenre",
                columns: new[] { "MovieId", "GanreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StateAndRate",
                table: "StateAndRate",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratio",
                table: "Ratio",
                columns: new[] { "MovieId", "FilmUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserToGenre_GanreId",
                table: "UserToGenre",
                column: "GanreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToGenre_UserId_GanreId",
                table: "UserToGenre",
                columns: new[] { "UserId", "GanreId" },
                unique: true);

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
                name: "IX_Movies_FilmingUnitId",
                table: "Movies",
                column: "FilmingUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUser_Id",
                table: "ImageUser",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageUnit_Id",
                table: "ImageUnit",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageMovies_Id",
                table: "ImageMovies",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StateAndRate_MovieId_UserId",
                table: "StateAndRate",
                columns: new[] { "MovieId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratio_MovieId_FilmUnitId",
                table: "Ratio",
                columns: new[] { "MovieId", "FilmUnitId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_FilmingUnits_FilmingUnitId",
                table: "Movies",
                column: "FilmingUnitId",
                principalTable: "FilmingUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratio_FilmingUnits_FilmUnitId",
                table: "Ratio",
                column: "FilmUnitId",
                principalTable: "FilmingUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratio_Movies_MovieId",
                table: "Ratio",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateAndRate_Movies_MovieId",
                table: "StateAndRate",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StateAndRate_Users_UserId",
                table: "StateAndRate",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_FilmingUnits_FilmingUnitId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratio_FilmingUnits_FilmUnitId",
                table: "Ratio");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratio_Movies_MovieId",
                table: "Ratio");

            migrationBuilder.DropForeignKey(
                name: "FK_StateAndRate_Movies_MovieId",
                table: "StateAndRate");

            migrationBuilder.DropForeignKey(
                name: "FK_StateAndRate_Users_UserId",
                table: "StateAndRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToGenre",
                table: "UserToGenre");

            migrationBuilder.DropIndex(
                name: "IX_UserToGenre_GanreId",
                table: "UserToGenre");

            migrationBuilder.DropIndex(
                name: "IX_UserToGenre_UserId_GanreId",
                table: "UserToGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieToGenre",
                table: "MovieToGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieToGenre_GanreId",
                table: "MovieToGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieToGenre_MovieId_GanreId",
                table: "MovieToGenre");

            migrationBuilder.DropIndex(
                name: "IX_Movies_FilmingUnitId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_ImageUser_Id",
                table: "ImageUser");

            migrationBuilder.DropIndex(
                name: "IX_ImageUnit_Id",
                table: "ImageUnit");

            migrationBuilder.DropIndex(
                name: "IX_ImageMovies_Id",
                table: "ImageMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StateAndRate",
                table: "StateAndRate");

            migrationBuilder.DropIndex(
                name: "IX_StateAndRate_MovieId_UserId",
                table: "StateAndRate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratio",
                table: "Ratio");

            migrationBuilder.DropIndex(
                name: "IX_Ratio_MovieId_FilmUnitId",
                table: "Ratio");

            migrationBuilder.DropColumn(
                name: "FilmingUnitId",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "StateAndRate",
                newName: "StatesAndRates");

            migrationBuilder.RenameTable(
                name: "Ratio",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_StateAndRate_UserId",
                table: "StatesAndRates",
                newName: "IX_StatesAndRates_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratio_FilmUnitId",
                table: "Roles",
                newName: "IX_Roles_FilmUnitId");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "UserToGenre",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "StatesAndRates",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Actor",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Актёр");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToGenre",
                table: "UserToGenre",
                columns: new[] { "GanreId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieToGenre",
                table: "MovieToGenre",
                columns: new[] { "GanreId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatesAndRates",
                table: "StatesAndRates",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                columns: new[] { "MovieId", "FilmUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserToGenre_UserId",
                table: "UserToGenre",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieToGenre_MovieId",
                table: "MovieToGenre",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_FilmingUnits_FilmUnitId",
                table: "Roles",
                column: "FilmUnitId",
                principalTable: "FilmingUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Movies_MovieId",
                table: "Roles",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatesAndRates_Movies_MovieId",
                table: "StatesAndRates",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatesAndRates_Users_UserId",
                table: "StatesAndRates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
