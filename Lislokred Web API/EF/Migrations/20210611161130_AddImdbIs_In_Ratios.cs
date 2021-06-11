using Microsoft.EntityFrameworkCore.Migrations;

namespace Lislokred_Web_API.Migrations
{
    public partial class AddImdbIs_In_Ratios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieImdbId",
                table: "Ratio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Orderig",
                table: "Ratio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UnitImdbId",
                table: "Ratio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Сharacter",
                table: "Ratio",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieImdbId",
                table: "Ratio");

            migrationBuilder.DropColumn(
                name: "Orderig",
                table: "Ratio");

            migrationBuilder.DropColumn(
                name: "UnitImdbId",
                table: "Ratio");

            migrationBuilder.DropColumn(
                name: "Сharacter",
                table: "Ratio");
        }
    }
}
