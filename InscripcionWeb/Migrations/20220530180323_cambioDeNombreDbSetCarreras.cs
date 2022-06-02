using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InscripcionWeb.Migrations
{
    public partial class cambioDeNombreDbSetCarreras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrera",
                table: "Carrera");

            migrationBuilder.RenameTable(
                name: "Carrera",
                newName: "Carreras");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carreras",
                table: "Carreras",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carreras",
                table: "Carreras");

            migrationBuilder.RenameTable(
                name: "Carreras",
                newName: "Carrera");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrera",
                table: "Carrera",
                column: "Id");
        }
    }
}
