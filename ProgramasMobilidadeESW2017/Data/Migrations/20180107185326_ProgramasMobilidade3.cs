using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Data.Migrations
{
    public partial class ProgramasMobilidade3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "TiposProgramaMobilidade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designacao",
                table: "TiposProgramaMobilidade",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "TiposProgramaMobilidade");

            migrationBuilder.DropColumn(
                name: "Designacao",
                table: "TiposProgramaMobilidade");
        }
    }
}
