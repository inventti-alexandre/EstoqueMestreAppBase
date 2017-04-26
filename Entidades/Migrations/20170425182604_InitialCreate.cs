using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entidades.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Deletado = table.Column<bool>(nullable: false)                                       
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    IdFornecedor = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Ativo = table.Column<bool>(nullable: false),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.IdFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 150, nullable: true),
                    EstoqueBaixo = table.Column<bool>(nullable: false),
                    IdFornecedor = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    ValorCompra = table.Column<decimal>(nullable: false),
                    ValorVenda = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    IdMovimentacao = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Estornada = table.Column<bool>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    IdFornecedor = table.Column<int>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 150, nullable: true),
                    Quantidade = table.Column<decimal>(nullable: false),
                    TipoOperacao = table.Column<char>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.IdMovimentacao);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Fornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_IdCliente",
                table: "Movimentacao",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_IdFornecedor",
                table: "Movimentacao",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_IdProduto",
                table: "Movimentacao",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdFornecedor",
                table: "Produto",
                column: "IdFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
