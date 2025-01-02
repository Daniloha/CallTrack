using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CallTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reasons",
                columns: table => new
                {
                    reason_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    reason_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("reason_id", x => x.reason_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnalystId = table.Column<long>(type: "bigint", nullable: false),
                    ManagerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "managers",
                columns: table => new
                {
                    manager_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    manager_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managers", x => x.manager_id);
                    table.ForeignKey(
                        name: "FK_managers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "analysts",
                columns: table => new
                {
                    analyst_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    analyst_status = table.Column<int>(type: "int", nullable: false, defaultValue: 4),
                    analyst_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    manager_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analysts", x => x.analyst_id);
                    table.ForeignKey(
                        name: "FK_analysts_managers_ManagerId",
                        column: x => x.manager_id,
                        principalTable: "managers",
                        principalColumn: "manager_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "calls",
                columns: table => new
                {
                    call_id = table.Column<long>(type: "bigint", nullable: false),
                    reason_id = table.Column<long>(type: "bigint", nullable: false),
                    call_observation = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    call_close_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    call_open_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    call_type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    call_code = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    call_status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    analyst_id = table.Column<long>(type: "bigint", nullable: false),
                    AnalystId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calls", x => x.call_id);
                    table.ForeignKey(
                        name: "FK_calls_analysts_AnalystId1",
                        column: x => x.AnalystId1,
                        principalTable: "analysts",
                        principalColumn: "analyst_id");
                    table.ForeignKey(
                        name: "FK_calls_analysts_analyst_id",
                        column: x => x.analyst_id,
                        principalTable: "analysts",
                        principalColumn: "analyst_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_calls_reasons_call_id",
                        column: x => x.call_id,
                        principalTable: "reasons",
                        principalColumn: "reason_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "reasons",
                columns: new[] { "reason_id", "reason_description" },
                values: new object[,]
                {
                    { 1L, "PIX" },
                    { 2L, "Saldo Bloqueado" },
                    { 3L, "Fila Errada" },
                    { 4L, "Duplicado" },
                    { 5L, "Erro de acesso ao app" },
                    { 6L, "Orientação" },
                    { 7L, "Erro Geral / Intermitência" },
                    { 8L, "Cancelamento de Cartão" },
                    { 9L, "Cancelamento Conta" },
                    { 10L, "Alteração Cadastral" },
                    { 11L, "Alteração de Type" },
                    { 12L, "Conta Topázio" },
                    { 13L, "Desassociação" },
                    { 14L, "Redefinição de Senha" },
                    { 15L, "SMS" },
                    { 16L, "Token de Ativação" },
                    { 17L, "Chip APAG" },
                    { 18L, "Maquininha" },
                    { 19L, "QR Code" },
                    { 20L, "Saque Tecban" },
                    { 21L, "Transferencia" },
                    { 22L, "Devolução da Maquininha" },
                    { 23L, "Conta congelada" },
                    { 24L, "Conta encerrada" },
                    { 25L, "Conta Bloqueada" },
                    { 26L, "Chamado Teste" },
                    { 27L, "Credito em Conta" },
                    { 28L, "Não aparece conta/cartao" },
                    { 29L, "Parâmetros Inválidos APP" },
                    { 30L, "Parâmetros Inválidos Maquininha" },
                    { 31L, "Relatorio de vendas app" },
                    { 32L, "Transação APAG" },
                    { 33L, "Reset de Chip" },
                    { 34L, "Cancelamento Transação" },
                    { 35L, "Estorno Adesão Apag" },
                    { 36L, "Efeito de Contrato" },
                    { 37L, "Boleto Pagamento" },
                    { 38L, "Informe de rendimentos" },
                    { 39L, "E-mail Suspeito" },
                    { 40L, "Bloqueio judicial" },
                    { 41L, "Recarga Bilhete Único" },
                    { 42L, "Erro de Biometria" },
                    { 43L, "Sem Grupo de Acesso" },
                    { 44L, "Sem Cadastro de Loja" },
                    { 45L, "Proposta Recusada" },
                    { 46L, "Sem Limite para Beneficio" },
                    { 47L, "Erro Sistêmico" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_analysts_manager_id",
                table: "analysts",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_analysts_user_id",
                table: "analysts",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_calls_analyst_id",
                table: "calls",
                column: "analyst_id");

            migrationBuilder.CreateIndex(
                name: "IX_calls_AnalystId1",
                table: "calls",
                column: "AnalystId1");

            migrationBuilder.CreateIndex(
                name: "IX_managers_UserId",
                table: "managers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calls");

            migrationBuilder.DropTable(
                name: "analysts");

            migrationBuilder.DropTable(
                name: "reasons");

            migrationBuilder.DropTable(
                name: "managers");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
