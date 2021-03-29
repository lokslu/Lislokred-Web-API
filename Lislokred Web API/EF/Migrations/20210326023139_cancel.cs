using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lislokred_Web_API.Migrations
{
    public partial class cancel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Ratio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Актёр",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Актёр");

            migrationBuilder.AlterColumn<bool>(
                name: "IsMain",
                table: "ImageUser",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

                        

        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Ratio",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "АктёH",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Актёр");

            

            migrationBuilder.AlterColumn<bool>(
                name: "IsMain",
                table: "ImageUnit",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

        }
    }
}
