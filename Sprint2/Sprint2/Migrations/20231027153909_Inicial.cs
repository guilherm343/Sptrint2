using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprint2.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "tbCliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "tbFornecedor",
                columns: table => new
                {
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFornecedor", x => x.FornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "tbVenda",
                columns: table => new
                {
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroNota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVenda", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_tbVenda_tbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tbCliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbProduto",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProduto", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_tbProduto_tbCategoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tbCategoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbProduto_tbFornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "tbFornecedor",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbItemVenda",
                columns: table => new
                {
                    ItemVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbItemVenda", x => x.ItemVendaId);
                    table.ForeignKey(
                        name: "FK_tbItemVenda_tbProduto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tbProduto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbItemVenda_tbVenda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "tbVenda",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbItemVenda_ProdutoId",
                table: "tbItemVenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbItemVenda_VendaId",
                table: "tbItemVenda",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduto_CategoriaId",
                table: "tbProduto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduto_FornecedorId",
                table: "tbProduto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVenda_ClienteId",
                table: "tbVenda",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbItemVenda");

            migrationBuilder.DropTable(
                name: "tbProduto");

            migrationBuilder.DropTable(
                name: "tbVenda");

            migrationBuilder.DropTable(
                name: "tbCategoria");

            migrationBuilder.DropTable(
                name: "tbFornecedor");

            migrationBuilder.DropTable(
                name: "tbCliente");
        }
    }
}
