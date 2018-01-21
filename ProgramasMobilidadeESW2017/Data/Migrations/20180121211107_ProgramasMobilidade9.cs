using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Data.Migrations
{
    public partial class ProgramasMobilidade9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TelefonePessoaContacto",
                table: "Candidaturas",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Candidaturas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidaturas_ProgramaMobilidadeID",
                table: "Candidaturas",
                column: "ProgramaMobilidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidaturas_UserId",
                table: "Candidaturas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidaturas_ProgramasMobilidade_ProgramaMobilidadeID",
                table: "Candidaturas",
                column: "ProgramaMobilidadeID",
                principalTable: "ProgramasMobilidade",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidaturas_AspNetUsers_UserId",
                table: "Candidaturas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidaturas_ProgramasMobilidade_ProgramaMobilidadeID",
                table: "Candidaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidaturas_AspNetUsers_UserId",
                table: "Candidaturas");

            migrationBuilder.DropIndex(
                name: "IX_Candidaturas_ProgramaMobilidadeID",
                table: "Candidaturas");

            migrationBuilder.DropIndex(
                name: "IX_Candidaturas_UserId",
                table: "Candidaturas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Candidaturas");

            migrationBuilder.AlterColumn<string>(
                name: "TelefonePessoaContacto",
                table: "Candidaturas",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
