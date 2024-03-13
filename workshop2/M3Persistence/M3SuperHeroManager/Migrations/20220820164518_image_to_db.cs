using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M3SuperHeroManager.Migrations
{
    public partial class image_to_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Heroes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Heroes");
        }
    }
}
