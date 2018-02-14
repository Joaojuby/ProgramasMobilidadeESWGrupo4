using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Data.Migrations
{
    public partial class ProgramasMobilidade12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URLImagem",
                table: "TiposProgramaMobilidade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URLBandeira",
                table: "Paises",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLImagem",
                table: "TiposProgramaMobilidade");

            migrationBuilder.DropColumn(
                name: "URLBandeira",
                table: "Paises");
        }
    }
}
