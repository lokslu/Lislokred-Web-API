using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lislokred_Web_API.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_FilmingUnits_FilmingUnitId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_FilmingUnitId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "FilmingUnitId",
                table: "Movies");

            migrationBuilder.AlterColumn<bool>(
                name: "IsMain",
                table: "ImageUser",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FilmingUnitId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMain",
                table: "ImageUser",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FilmingUnitId",
                table: "Movies",
                column: "FilmingUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_FilmingUnits_FilmingUnitId",
                table: "Movies",
                column: "FilmingUnitId",
                principalTable: "FilmingUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
