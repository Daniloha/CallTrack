using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CallTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedReasons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_analysts_managers_managerId",
                table: "analysts");

            migrationBuilder.DropForeignKey(
                name: "FK_analysts_users_userId",
                table: "analysts");

            migrationBuilder.DropForeignKey(
                name: "FK_calls_analysts_analystId",
                table: "calls");

            migrationBuilder.DropForeignKey(
                name: "FK_managers_users_userId",
                table: "managers");

            migrationBuilder.DropForeignKey(
                name: "FK_reasons_calls_CallscallId",
                table: "reasons");

            migrationBuilder.DropIndex(
                name: "IX_reasons_CallscallId",
                table: "reasons");

            migrationBuilder.DropColumn(
                name: "CallscallId",
                table: "reasons");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "managers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_managers_userId",
                table: "managers",
                newName: "IX_managers_UserId");

            migrationBuilder.RenameColumn(
                name: "analystId",
                table: "calls",
                newName: "AnalystId");

            migrationBuilder.RenameIndex(
                name: "IX_calls_analystId",
                table: "calls",
                newName: "IX_calls_AnalystId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "analysts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "managerId",
                table: "analysts",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_analysts_userId",
                table: "analysts",
                newName: "IX_analysts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_analysts_managerId",
                table: "analysts",
                newName: "IX_analysts_ManagerId");

            migrationBuilder.AddColumn<long>(
                name: "ReasonId",
                table: "calls",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ReasonsReasonId",
                table: "calls",
                type: "bigint",
                nullable: true);

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
                name: "IX_calls_ReasonsReasonId",
                table: "calls",
                column: "ReasonsReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_analysts_managers_ManagerId",
                table: "analysts",
                column: "ManagerId",
                principalTable: "managers",
                principalColumn: "manager_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_analysts_users_UserId",
                table: "analysts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_calls_analysts_AnalystId",
                table: "calls",
                column: "AnalystId",
                principalTable: "analysts",
                principalColumn: "analyst_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_calls_reasons_ReasonsReasonId",
                table: "calls",
                column: "ReasonsReasonId",
                principalTable: "reasons",
                principalColumn: "reason_id");

            migrationBuilder.AddForeignKey(
                name: "FK_managers_users_UserId",
                table: "managers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_analysts_managers_ManagerId",
                table: "analysts");

            migrationBuilder.DropForeignKey(
                name: "FK_analysts_users_UserId",
                table: "analysts");

            migrationBuilder.DropForeignKey(
                name: "FK_calls_analysts_AnalystId",
                table: "calls");

            migrationBuilder.DropForeignKey(
                name: "FK_calls_reasons_ReasonsReasonId",
                table: "calls");

            migrationBuilder.DropForeignKey(
                name: "FK_managers_users_UserId",
                table: "managers");

            migrationBuilder.DropIndex(
                name: "IX_calls_ReasonsReasonId",
                table: "calls");

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "reasons",
                keyColumn: "reason_id",
                keyValue: 47L);

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "calls");

            migrationBuilder.DropColumn(
                name: "ReasonsReasonId",
                table: "calls");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "managers",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_managers_UserId",
                table: "managers",
                newName: "IX_managers_userId");

            migrationBuilder.RenameColumn(
                name: "AnalystId",
                table: "calls",
                newName: "analystId");

            migrationBuilder.RenameIndex(
                name: "IX_calls_AnalystId",
                table: "calls",
                newName: "IX_calls_analystId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "analysts",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "analysts",
                newName: "managerId");

            migrationBuilder.RenameIndex(
                name: "IX_analysts_UserId",
                table: "analysts",
                newName: "IX_analysts_userId");

            migrationBuilder.RenameIndex(
                name: "IX_analysts_ManagerId",
                table: "analysts",
                newName: "IX_analysts_managerId");

            migrationBuilder.AddColumn<long>(
                name: "CallscallId",
                table: "reasons",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reasons_CallscallId",
                table: "reasons",
                column: "CallscallId");

            migrationBuilder.AddForeignKey(
                name: "FK_analysts_managers_managerId",
                table: "analysts",
                column: "managerId",
                principalTable: "managers",
                principalColumn: "manager_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_analysts_users_userId",
                table: "analysts",
                column: "userId",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_calls_analysts_analystId",
                table: "calls",
                column: "analystId",
                principalTable: "analysts",
                principalColumn: "analyst_id");

            migrationBuilder.AddForeignKey(
                name: "FK_managers_users_userId",
                table: "managers",
                column: "userId",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reasons_calls_CallscallId",
                table: "reasons",
                column: "CallscallId",
                principalTable: "calls",
                principalColumn: "call_id");
        }
    }
}
