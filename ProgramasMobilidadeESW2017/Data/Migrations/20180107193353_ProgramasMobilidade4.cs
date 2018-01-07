using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Data.Migrations
{
    public partial class ProgramasMobilidade4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pais",
                table: "ProgramasMobilidade");

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoISO = table.Column<string>(nullable: true),
                    CodigoPais = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    ProgramaMobilidadeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Paises_ProgramasMobilidade_ProgramaMobilidadeID",
                        column: x => x.ProgramaMobilidadeID,
                        principalTable: "ProgramasMobilidade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    PaisID = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instituicoes_Paises_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Paises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instituicoes_PaisID",
                table: "Instituicoes",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_ProgramaMobilidadeID",
                table: "Paises",
                column: "ProgramaMobilidadeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instituicoes");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "ProgramasMobilidade",
                nullable: true);
        }
    }
}
