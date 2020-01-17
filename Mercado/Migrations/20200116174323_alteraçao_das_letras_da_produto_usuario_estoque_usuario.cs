using Microsoft.EntityFrameworkCore.Migrations;

namespace Mercado.Migrations
{
    public partial class alteraçao_das_letras_da_produto_usuario_estoque_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produto_produtoId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Usuario_usuarioId",
                table: "Vendas");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Vendas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "produtoId",
                table: "Vendas",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_usuarioId",
                table: "Vendas",
                newName: "IX_Vendas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_produtoId",
                table: "Vendas",
                newName: "IX_Vendas_ProdutoId");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Estoque",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_UsuarioId",
                table: "Estoque",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Usuario_UsuarioId",
                table: "Estoque",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produto_ProdutoId",
                table: "Vendas",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Usuario_UsuarioId",
                table: "Vendas",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Usuario_UsuarioId",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produto_ProdutoId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Usuario_UsuarioId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_UsuarioId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Estoque");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Vendas",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Vendas",
                newName: "produtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_UsuarioId",
                table: "Vendas",
                newName: "IX_Vendas_usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_ProdutoId",
                table: "Vendas",
                newName: "IX_Vendas_produtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produto_produtoId",
                table: "Vendas",
                column: "produtoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Usuario_usuarioId",
                table: "Vendas",
                column: "usuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
