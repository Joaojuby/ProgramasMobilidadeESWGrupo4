using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgramasMobilidadeESW2017.Data.Migrations
{
    public partial class ProgramasMobilidade6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instituicoes_Paises_PaisID",
                table: "Instituicoes");

            migrationBuilder.AlterColumn<int>(
                name: "PaisID",
                table: "Instituicoes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instituicoes_Paises_PaisID",
                table: "Instituicoes",
                column: "PaisID",
                principalTable: "Paises",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instituicoes_Paises_PaisID",
                table: "Instituicoes");

            migrationBuilder.AlterColumn<int>(
                name: "PaisID",
                table: "Instituicoes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Instituicoes_Paises_PaisID",
                table: "Instituicoes",
                column: "PaisID",
                principalTable: "Paises",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
