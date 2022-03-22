using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lislokred_Web_API.Migrations
{
    public partial class Add_base_genres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Data" },
                values: new object[,]
                {
                    { 1, "Detective" },
                    { 2, "Drama" },
                    { 3, "Сomedy" },
                    { 4, "Fantastic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
