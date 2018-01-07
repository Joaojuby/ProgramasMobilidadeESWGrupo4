using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Data.Migrations
{
    public partial class ProgramasMobilidade2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposProgramaMobilidade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProgramaMobilidade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProgramasMobilidade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicioInscricao = table.Column<DateTime>(nullable: false),
                    DataLimiteInscricao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Duracao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    TipoProgramaMobilidadeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramasMobilidade", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgramasMobilidade_TiposProgramaMobilidade_TipoProgramaMobilidadeID",
                        column: x => x.TipoProgramaMobilidadeID,
                        principalTable: "TiposProgramaMobilidade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramasMobilidade_TipoProgramaMobilidadeID",
                table: "ProgramasMobilidade",
                column: "TipoProgramaMobilidadeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramasMobilidade");

            migrationBuilder.DropTable(
                name: "TiposProgramaMobilidade");
        }
    }
}
