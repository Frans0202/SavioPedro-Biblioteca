using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    id_aut = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome_aut = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nacionalidade_aut = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_nascimento_aut = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.id_aut);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "livros",
                columns: table => new
                {
                    id_liv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titulo_liv = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isbn_liv = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    editora_liv = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ano_publicacao_liv = table.Column<int>(type: "int", nullable: false),
                    genero_liv = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantidade_total_liv = table.Column<int>(type: "int", nullable: false),
                    quantidade_disponivel_liv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livros", x => x.id_liv);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome_usu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cpf_usu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_nascimento_usu = table.Column<DateOnly>(type: "date", nullable: false),
                    telefone_usu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email_usu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endereco_usu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usu);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AutorLivro",
                columns: table => new
                {
                    AutoresId = table.Column<int>(type: "int", nullable: false),
                    LivrosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLivro", x => new { x.AutoresId, x.LivrosId });
                    table.ForeignKey(
                        name: "FK_AutorLivro_autores_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "autores",
                        principalColumn: "id_aut",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLivro_livros_LivrosId",
                        column: x => x.LivrosId,
                        principalTable: "livros",
                        principalColumn: "id_liv",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "emprestimos",
                columns: table => new
                {
                    id_emp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuario_id_emp = table.Column<int>(type: "int", nullable: false),
                    livro_id_emp = table.Column<int>(type: "int", nullable: false),
                    data_emprestimo_emp = table.Column<DateOnly>(type: "date", nullable: false),
                    data_prevista_devolucao_emp = table.Column<DateOnly>(type: "date", nullable: false),
                    data_efetiva_devolucao_emp = table.Column<DateOnly>(type: "date", nullable: true),
                    valor_multa_emp = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprestimos", x => x.id_emp);
                    table.ForeignKey(
                        name: "FK_emprestimos_livros_livro_id_emp",
                        column: x => x.livro_id_emp,
                        principalTable: "livros",
                        principalColumn: "id_liv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emprestimos_usuarios_usuario_id_emp",
                        column: x => x.usuario_id_emp,
                        principalTable: "usuarios",
                        principalColumn: "id_usu",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reservas",
                columns: table => new
                {
                    id_res = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuario_id_res = table.Column<int>(type: "int", nullable: false),
                    livro_id_res = table.Column<int>(type: "int", nullable: false),
                    data_reserva_res = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    posicao_fila_res = table.Column<int>(type: "int", nullable: false),
                    data_expiracao_res = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status_res = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservas", x => x.id_res);
                    table.ForeignKey(
                        name: "FK_reservas_livros_livro_id_res",
                        column: x => x.livro_id_res,
                        principalTable: "livros",
                        principalColumn: "id_liv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservas_usuarios_usuario_id_res",
                        column: x => x.usuario_id_res,
                        principalTable: "usuarios",
                        principalColumn: "id_usu",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "penalidades",
                columns: table => new
                {
                    id_pen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuario_id_pen = table.Column<int>(type: "int", nullable: false),
                    emprestimo_id_pen = table.Column<int>(type: "int", nullable: false),
                    data_pen = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    dias_atraso_pen = table.Column<int>(type: "int", nullable: false),
                    valor_multa_pen = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    status_pagamento_pen = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_penalidades", x => x.id_pen);
                    table.ForeignKey(
                        name: "FK_penalidades_emprestimos_emprestimo_id_pen",
                        column: x => x.emprestimo_id_pen,
                        principalTable: "emprestimos",
                        principalColumn: "id_emp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_penalidades_usuarios_usuario_id_pen",
                        column: x => x.usuario_id_pen,
                        principalTable: "usuarios",
                        principalColumn: "id_usu",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AutorLivro_LivrosId",
                table: "AutorLivro",
                column: "LivrosId");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimos_livro_id_emp",
                table: "emprestimos",
                column: "livro_id_emp");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimos_usuario_id_emp",
                table: "emprestimos",
                column: "usuario_id_emp");

            migrationBuilder.CreateIndex(
                name: "IX_penalidades_emprestimo_id_pen",
                table: "penalidades",
                column: "emprestimo_id_pen");

            migrationBuilder.CreateIndex(
                name: "IX_penalidades_usuario_id_pen",
                table: "penalidades",
                column: "usuario_id_pen");

            migrationBuilder.CreateIndex(
                name: "IX_reservas_livro_id_res",
                table: "reservas",
                column: "livro_id_res");

            migrationBuilder.CreateIndex(
                name: "IX_reservas_usuario_id_res",
                table: "reservas",
                column: "usuario_id_res");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorLivro");

            migrationBuilder.DropTable(
                name: "penalidades");

            migrationBuilder.DropTable(
                name: "reservas");

            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropTable(
                name: "emprestimos");

            migrationBuilder.DropTable(
                name: "livros");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
