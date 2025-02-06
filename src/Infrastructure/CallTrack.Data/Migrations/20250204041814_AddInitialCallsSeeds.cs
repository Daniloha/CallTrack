using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialCallsSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insere 10 exemplos de Calls com analyst_id limitados a 1 ou 2
            migrationBuilder.Sql("INSERT INTO calls (reason_id, call_observation, call_open_date, call_close_date, call_type, call_code, call_status, analyst_id) VALUES " +
                                  "(1, 'Chamada sobre erro de saldo bloqueado', '2025-02-04 08:00:00', '2025-02-04 08:30:00', 0, 'C001', 0, 1)," +
                                  "(2, 'Cliente reportando fila errada', '2025-02-04 09:00:00', '2025-02-04 09:45:00', 0, 'C002', 0, 2)," +
                                  "(3, 'Cancelamento de cartão solicitado', '2025-02-04 10:00:00', '2025-02-04 10:20:00', 1, 'C003', 1, 1)," +
                                  "(4, 'Erro de acesso ao app', '2025-02-04 11:00:00', '2025-02-04 11:15:00', 0, 'C004', 0, 2)," +
                                  "(5, 'Duplicação de cobrança encontrada', '2025-02-04 12:00:00', '2025-02-04 12:30:00', 0, 'C005', 0, 1)," +
                                  "(6, 'Problema com a maquininha de pagamento', '2025-02-04 13:00:00', '2025-02-04 13:45:00', 0, 'C006', 1, 2)," +
                                  "(7, 'Solicitação de mudança de tipo de conta', '2025-02-04 14:00:00', '2025-02-04 14:30:00', 0, 'C007', 0, 1)," +
                                  "(8, 'Cliente reportando erro de PIN', '2025-02-04 15:00:00', '2025-02-04 15:15:00', 1, 'C008', 1, 2)," +
                                  "(9, 'Erro sistêmico durante transação', '2025-02-04 16:00:00', '2025-02-04 16:30:00', 0, 'C009', 0, 1)," +
                                  "(10, 'Cliente cancelou conta após problema recorrente', '2025-02-04 17:00:00', '2025-02-04 17:45:00', 0, 'C010', 0, 2);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Se necessário, você pode adicionar um código para reverter a inserção desses dados.
            migrationBuilder.Sql("DELETE FROM calls;");
        }
    }
}
