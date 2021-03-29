using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lislokred_Web_API.Migrations
{
    public partial class checkDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<bool>(
                name: "IsMain",
                table: "ImageUnit",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AlterColumn<bool>(
                name: "IsMain",
                table: "ImageUnit",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

       
        }
    }
}
