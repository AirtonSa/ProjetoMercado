using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.Migrations
{
    public partial class atribuindo_tipolancamento_no_estoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoLancamentoId",
                table: "Estoque",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoLancamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLancamento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_TipoLancamentoId",
                table: "Estoque",
                column: "TipoLancamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_TipoLancamento_TipoLancamentoId",
                table: "Estoque",
                column: "TipoLancamentoId",
                principalTable: "TipoLancamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_TipoLancamento_TipoLancamentoId",
                table: "Estoque");

            migrationBuilder.DropTable(
                name: "TipoLancamento");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_TipoLancamentoId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "TipoLancamentoId",
                table: "Estoque");
        }
    }
}
