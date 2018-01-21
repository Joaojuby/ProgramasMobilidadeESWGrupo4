using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Data.Migrations
{
    public partial class ProgramasMobilidade8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ProgramasMobilidade",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ProgramasMobilidade",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstadosCandidaturas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCandidaturas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Candidaturas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstadoCandidaturaID = table.Column<int>(nullable: false),
                    NomePessoaContacto = table.Column<string>(nullable: false),
                    ProgramaMobilidadeID = table.Column<int>(nullable: false),
                    RelacaoComCandidato = table.Column<string>(nullable: false),
                    TelefonePessoaContacto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidaturas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Candidaturas_EstadosCandidaturas_EstadoCandidaturaID",
                        column: x => x.EstadoCandidaturaID,
                        principalTable: "EstadosCandidaturas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entrevistas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidaturaID = table.Column<int>(nullable: true),
                    DataEntrevista = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrevistas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Entrevistas_Candidaturas_CandidaturaID",
                        column: x => x.CandidaturaID,
                        principalTable: "Candidaturas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObservacoesCandidaturas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidaturaID = table.Column<int>(nullable: true),
                    Nota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObservacoesCandidaturas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ObservacoesCandidaturas_Candidaturas_CandidaturaID",
                        column: x => x.CandidaturaID,
                        principalTable: "Candidaturas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidaturas_EstadoCandidaturaID",
                table: "Candidaturas",
                column: "EstadoCandidaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_Entrevistas_CandidaturaID",
                table: "Entrevistas",
                column: "CandidaturaID");

            migrationBuilder.CreateIndex(
                name: "IX_ObservacoesCandidaturas_CandidaturaID",
                table: "ObservacoesCandidaturas",
                column: "CandidaturaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrevistas");

            migrationBuilder.DropTable(
                name: "ObservacoesCandidaturas");

            migrationBuilder.DropTable(
                name: "Candidaturas");

            migrationBuilder.DropTable(
                name: "EstadosCandidaturas");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "ProgramasMobilidade",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ProgramasMobilidade",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
