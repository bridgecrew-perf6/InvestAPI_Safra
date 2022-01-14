using Microsoft.EntityFrameworkCore.Migrations;

namespace Invest.Repositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acao",
                columns: table => new
                {
                    acao_id = table.Column<string>(type: "TEXT", nullable: false),
                    razao_social = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acao", x => x.acao_id);
                });

            migrationBuilder.CreateTable(
                name: "Operacoes",
                columns: table => new
                {
                    OperacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AcaoId = table.Column<string>(type: "TEXT", nullable: true),
                    PrecoAcao = table.Column<double>(type: "REAL", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoOperacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacoes", x => x.OperacaoId);
                    table.ForeignKey(
                        name: "FK_Operacoes_acao_AcaoId",
                        column: x => x.AcaoId,
                        principalTable: "acao",
                        principalColumn: "acao_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operacoes_AcaoId",
                table: "Operacoes",
                column: "AcaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operacoes");

            migrationBuilder.DropTable(
                name: "acao");
        }
    }
}
