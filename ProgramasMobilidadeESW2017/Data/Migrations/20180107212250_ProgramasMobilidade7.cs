using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Data.Migrations
{
    public partial class ProgramasMobilidade7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paises_ProgramasMobilidade_ProgramaMobilidadeID",
                table: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Paises_ProgramaMobilidadeID",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "ProgramaMobilidadeID",
                table: "Paises");

            migrationBuilder.CreateTable(
                name: "ProgramasMobilidadePais",
                columns: table => new
                {
                    PaisID = table.Column<int>(nullable: false),
                    ProgramaMobilidadeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramasMobilidadePais", x => new { x.PaisID, x.ProgramaMobilidadeID });
                    table.ForeignKey(
                        name: "FK_ProgramasMobilidadePais_Paises_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Paises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramasMobilidadePais_ProgramasMobilidade_ProgramaMobilidadeID",
                        column: x => x.ProgramaMobilidadeID,
                        principalTable: "ProgramasMobilidade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramasMobilidadePais_ProgramaMobilidadeID",
                table: "ProgramasMobilidadePais",
                column: "ProgramaMobilidadeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramasMobilidadePais");

            migrationBuilder.AddColumn<int>(
                name: "ProgramaMobilidadeID",
                table: "Paises",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_ProgramaMobilidadeID",
                table: "Paises",
                column: "ProgramaMobilidadeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_ProgramasMobilidade_ProgramaMobilidadeID",
                table: "Paises",
                column: "ProgramaMobilidadeID",
                principalTable: "ProgramasMobilidade",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
