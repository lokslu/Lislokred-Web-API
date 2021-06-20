using Microsoft.EntityFrameworkCore.Migrations;

namespace Lislokred_Web_API.Migrations
{
    public partial class Add_property_IsAnotherSource_in_entitys_images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnotherSource",
                table: "ImageUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnotherSource",
                table: "ImageUnit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnotherSource",
                table: "ImageMovies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnotherSource",
                table: "ImageUser");

            migrationBuilder.DropColumn(
                name: "IsAnotherSource",
                table: "ImageUnit");

            migrationBuilder.DropColumn(
                name: "IsAnotherSource",
                table: "ImageMovies");
        }
    }
}
