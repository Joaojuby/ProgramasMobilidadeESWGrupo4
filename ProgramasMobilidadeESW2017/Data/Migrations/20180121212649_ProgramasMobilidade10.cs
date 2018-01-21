using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Data.Migrations
{
    public partial class ProgramasMobilidade10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrevistas_Candidaturas_CandidaturaID",
                table: "Entrevistas");

            migrationBuilder.DropForeignKey(
                name: "FK_ObservacoesCandidaturas_Candidaturas_CandidaturaID",
                table: "ObservacoesCandidaturas");

            migrationBuilder.AlterColumn<int>(
                name: "CandidaturaID",
                table: "ObservacoesCandidaturas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidaturaID",
                table: "Entrevistas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrevistas_Candidaturas_CandidaturaID",
                table: "Entrevistas",
                column: "CandidaturaID",
                principalTable: "Candidaturas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObservacoesCandidaturas_Candidaturas_CandidaturaID",
                table: "ObservacoesCandidaturas",
                column: "CandidaturaID",
                principalTable: "Candidaturas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrevistas_Candidaturas_CandidaturaID",
                table: "Entrevistas");

            migrationBuilder.DropForeignKey(
                name: "FK_ObservacoesCandidaturas_Candidaturas_CandidaturaID",
                table: "ObservacoesCandidaturas");

            migrationBuilder.AlterColumn<int>(
                name: "CandidaturaID",
                table: "ObservacoesCandidaturas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CandidaturaID",
                table: "Entrevistas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Entrevistas_Candidaturas_CandidaturaID",
                table: "Entrevistas",
                column: "CandidaturaID",
                principalTable: "Candidaturas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ObservacoesCandidaturas_Candidaturas_CandidaturaID",
                table: "ObservacoesCandidaturas",
                column: "CandidaturaID",
                principalTable: "Candidaturas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
