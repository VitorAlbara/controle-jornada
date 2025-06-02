using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace controle_jornada.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_versao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_versao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "versoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ProjetoId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataVencimento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_versoes", x => new { x.Id, x.ProjetoId });
                    table.ForeignKey(
                        name: "FK_versoes_projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Tamanho = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DataInicial = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFinal = table.Column<DateOnly>(type: "date", nullable: false),
                    Projeto = table.Column<int>(type: "integer", nullable: false),
                    VersaoId = table.Column<int>(type: "integer", nullable: false),
                    ProjetoVersaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarefas", x => new { x.Id, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_tarefas_versoes_VersaoId_ProjetoVersaoId",
                        columns: x => new { x.VersaoId, x.ProjetoVersaoId },
                        principalTable: "versoes",
                        principalColumns: new[] { "Id", "ProjetoId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TarefaId = table.Column<int>(type: "integer", nullable: false),
                    TarefaUsuarioId = table.Column<int>(type: "integer", nullable: false),
                    DataEntrada = table.Column<DateOnly>(type: "date", nullable: false),
                    Duracao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entradas_tarefas_TarefaId_TarefaUsuarioId",
                        columns: x => new { x.TarefaId, x.TarefaUsuarioId },
                        principalTable: "tarefas",
                        principalColumns: new[] { "Id", "UsuarioId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entradas_locais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TarefaId = table.Column<int>(type: "integer", nullable: false),
                    TarefaUsuarioId = table.Column<int>(type: "integer", nullable: false),
                    DataEntrada = table.Column<DateOnly>(type: "date", nullable: false),
                    Duracao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas_locais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entradas_locais_tarefas_TarefaId_TarefaUsuarioId",
                        columns: x => new { x.TarefaId, x.TarefaUsuarioId },
                        principalTable: "tarefas",
                        principalColumns: new[] { "Id", "UsuarioId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entradas_TarefaId_TarefaUsuarioId",
                table: "entradas",
                columns: new[] { "TarefaId", "TarefaUsuarioId" });

            migrationBuilder.CreateIndex(
                name: "IX_entradas_locais_TarefaId_TarefaUsuarioId",
                table: "entradas_locais",
                columns: new[] { "TarefaId", "TarefaUsuarioId" });

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_VersaoId_ProjetoVersaoId",
                table: "tarefas",
                columns: new[] { "VersaoId", "ProjetoVersaoId" });

            migrationBuilder.CreateIndex(
                name: "IX_versoes_ProjetoId",
                table: "versoes",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_versao");

            migrationBuilder.DropTable(
                name: "entradas");

            migrationBuilder.DropTable(
                name: "entradas_locais");

            migrationBuilder.DropTable(
                name: "tarefas");

            migrationBuilder.DropTable(
                name: "versoes");

            migrationBuilder.DropTable(
                name: "projetos");
        }
    }
}
