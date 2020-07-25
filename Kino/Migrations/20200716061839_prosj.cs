using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kino.Migrations
{
    public partial class prosj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "prosjecnaOcjena",
                table: "FilmOcjena",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prosjecnaOcjena",
                table: "FilmOcjena");

       
        }
    }
}
