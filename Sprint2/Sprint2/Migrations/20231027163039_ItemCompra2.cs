using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprint2.Migrations
{
    /// <inheritdoc />
    public partial class ItemCompra2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbCompra_tbFornecedor_FornecedorId",
                table: "tbCompra");

            migrationBuilder.DropIndex(
                name: "IX_tbCompra_FornecedorId",
                table: "tbCompra");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "tbCompra");

            migrationBuilder.CreateTable(
                name: "tbItemCompra",
                columns: table => new
                {
                    ItemCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbItemCompra", x => x.ItemCompraId);
                    table.ForeignKey(
                        name: "FK_tbItemCompra_tbCompra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "tbCompra",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbItemCompra_tbProduto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tbProduto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbItemCompra_CompraId",
                table: "tbItemCompra",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_tbItemCompra_ProdutoId",
                table: "tbItemCompra",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbItemCompra");

            migrationBuilder.AddColumn<Guid>(
                name: "FornecedorId",
                table: "tbCompra",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tbCompra_FornecedorId",
                table: "tbCompra",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbCompra_tbFornecedor_FornecedorId",
                table: "tbCompra",
                column: "FornecedorId",
                principalTable: "tbFornecedor",
                principalColumn: "FornecedorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
