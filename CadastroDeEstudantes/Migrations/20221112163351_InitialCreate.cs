using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeEstudantes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estudante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SenhaSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    InstituicaoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudante", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Estudante_Instituicao_InstituicaoID",
                        column: x => x.InstituicaoID,
                        principalTable: "Instituicao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudante_InstituicaoID",
                table: "Estudante",
                column: "InstituicaoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudante");

            migrationBuilder.DropTable(
                name: "Instituicao");
        }
    }
}
