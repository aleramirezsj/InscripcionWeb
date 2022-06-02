using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InscripcionWeb.Migrations
{
    public partial class agregamosMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodoAcademicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_PeriodosAcademicos_PeriodoAcademicoId",
                        column: x => x.PeriodoAcademicoId,
                        principalTable: "PeriodosAcademicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materias_PeriodoAcademicoId",
                table: "Materias",
                column: "PeriodoAcademicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materias");
        }
    }
}
