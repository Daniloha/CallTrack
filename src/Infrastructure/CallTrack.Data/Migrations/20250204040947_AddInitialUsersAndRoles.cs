using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Criar o Usuário (Manager)
            migrationBuilder.Sql("INSERT INTO Users (user_email, user_password) VALUES ('manager@example.com', 'manager123')");
            migrationBuilder.Sql("SET @ManagerUserId = LAST_INSERT_ID()");

            // Step 2: Criar o Manager e Atualizar o Usuário
            migrationBuilder.Sql("INSERT INTO Managers (manager_name, user_id) VALUES ('Manager One', @ManagerUserId)");
            migrationBuilder.Sql("SET @ManagerId = LAST_INSERT_ID()");
            migrationBuilder.Sql("UPDATE Users SET manager_id = @ManagerId WHERE user_id = @ManagerUserId");

            // Step 3: Criar o Usuário (Analyst)
            migrationBuilder.Sql("INSERT INTO Users (user_email, user_password) VALUES ('analyst@example.com', 'analyst123')");
            migrationBuilder.Sql("SET @AnalystUserId = LAST_INSERT_ID()");

            // Step 4: Criar o Analyst e Atualizar o Usuário
            migrationBuilder.Sql("INSERT INTO Analysts (analyst_name, analyst_status, user_id, manager_id) VALUES ('Analyst One', 2, @AnalystUserId, @ManagerId)");
            migrationBuilder.Sql("SET @AnalystId = LAST_INSERT_ID()");
            migrationBuilder.Sql("UPDATE Users SET analyst_id = @AnalystId WHERE user_id = @AnalystUserId");

            // Step 5: Criar o Segundo Usuário (Analyst)
            migrationBuilder.Sql("INSERT INTO Users (user_email, user_password) VALUES ('analyst2@example.com', 'analyst456')");
            migrationBuilder.Sql("SET @AnalystUserId2 = LAST_INSERT_ID()");

            // Step 6: Criar o Segundo Analyst e Atualizar o Usuário
            migrationBuilder.Sql("INSERT INTO Analysts (analyst_name, analyst_status, user_id, manager_id) VALUES ('Analyst Two', 2, @AnalystUserId2, @ManagerId)");
            migrationBuilder.Sql("SET @AnalystId2 = LAST_INSERT_ID()");
            migrationBuilder.Sql("UPDATE Users SET analyst_id = @AnalystId2 WHERE user_id = @AnalystUserId2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Aqui você pode adicionar o código para reverter a migration se necessário
            migrationBuilder.Sql("DELETE FROM Analysts WHERE analyst_id IS NOT NULL");
            migrationBuilder.Sql("DELETE FROM Managers WHERE manager_id IS NOT NULL");
            migrationBuilder.Sql("DELETE FROM Users WHERE user_id IS NOT NULL");
        }
    }
}
