using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSchool_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    DataNasc = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Vinícius" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Paula" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Luna" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNasc", "Endereco", "Nome", "ProfessorId" },
                values: new object[] { 1, "01/01/1988", "Rua general salvador pinheiro, 725", "Maria José", 1 });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNasc", "Endereco", "Nome", "ProfessorId" },
                values: new object[] { 2, "02/02/1978", "Rua machado de assis, 23", "João Paulo", 2 });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNasc", "Endereco", "Nome", "ProfessorId" },
                values: new object[] { 3, "03/03/1968", "Rua mostardeiro, 777", "Alex Ferraz", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProfessorId",
                table: "Alunos",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
