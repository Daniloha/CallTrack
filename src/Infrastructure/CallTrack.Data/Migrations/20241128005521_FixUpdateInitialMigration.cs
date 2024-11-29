using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUpdateInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_analysts_managers_ManagersManagerId",
                table: "analysts");

            migrationBuilder.DropForeignKey(
                name: "FK_analysts_users_UsersUserId",
                table: "analysts");

            migrationBuilder.DropForeignKey(
                name: "FK_calls_analysts_call_id",
                table: "calls");

            migrationBuilder.DropForeignKey(
                name: "FK_managers_users_UsersUserId",
                table: "managers");

            migrationBuilder.DropForeignKey(
                name: "FK_reasons_calls_reason_id",
                table: "reasons");

            migrationBuilder.DropIndex(
                name: "IX_managers_UsersUserId",
                table: "managers");

            migrationBuilder.DropIndex(
                name: "IX_analysts_ManagersManagerId",
                table: "analysts");

            migrationBuilder.DropIndex(
                name: "IX_analysts_UsersUserId",
                table: "analysts");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "ManagersManagerId",
                table: "analysts");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "analysts");

            migrationBuilder.RenameColumn(
                name: "open_date",
                table: "calls",
                newName: "openDate");

            migrationBuilder.RenameColumn(
                name: "close_date",
                table: "calls",
                newName: "closeDate");

            migrationBuilder.AlterColumn<long>(
                name: "reason_id",
                table: "reasons",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "CallscallId",
                table: "reasons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "userId",
                table: "managers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "call_id",
                table: "calls",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "analystId",
                table: "calls",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "managerId",
                table: "analysts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "userId",
                table: "analysts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_reasons_CallscallId",
                table: "reasons",
                column: "CallscallId");

            migrationBuilder.CreateIndex(
                name: "IX_managers_userId",
                table: "managers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_calls_analystId",
                table: "calls",
                column: "analystId");

            migrationBuilder.CreateIndex(
                name: "IX_analysts_managerId",
                table: "analysts",
                column: "managerId");

            migrationBuilder.CreateIndex(
                name: "IX_analysts_userId",
                table: "analysts",
                column: "userId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_managers_userId",
                table: "managers");

            migrationBuilder.DropIndex(
                name: "IX_calls_analystId",
                table: "calls");

            migrationBuilder.DropIndex(
                name: "IX_analysts_managerId",
                table: "analysts");

            migrationBuilder.DropIndex(
                name: "IX_analysts_userId",
                table: "analysts");

            migrationBuilder.DropColumn(
                name: "CallscallId",
                table: "reasons");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "managers");

            migrationBuilder.DropColumn(
                name: "analystId",
                table: "calls");

            migrationBuilder.DropColumn(
                name: "managerId",
                table: "analysts");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "analysts");

            migrationBuilder.RenameColumn(
                name: "openDate",
                table: "calls",
                newName: "open_date");

            migrationBuilder.RenameColumn(
                name: "closeDate",
                table: "calls",
                newName: "close_date");

            migrationBuilder.AlterColumn<long>(
                name: "reason_id",
                table: "reasons",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "UsersUserId",
                table: "managers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "call_id",
                table: "calls",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "ManagersManagerId",
                table: "analysts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsersUserId",
                table: "analysts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_managers_UsersUserId",
                table: "managers",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_analysts_ManagersManagerId",
                table: "analysts",
                column: "ManagersManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_analysts_UsersUserId",
                table: "analysts",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_analysts_managers_ManagersManagerId",
                table: "analysts",
                column: "ManagersManagerId",
                principalTable: "managers",
                principalColumn: "manager_id");

            migrationBuilder.AddForeignKey(
                name: "FK_analysts_users_UsersUserId",
                table: "analysts",
                column: "UsersUserId",
                principalTable: "users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_calls_analysts_call_id",
                table: "calls",
                column: "call_id",
                principalTable: "analysts",
                principalColumn: "analyst_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_managers_users_UsersUserId",
                table: "managers",
                column: "UsersUserId",
                principalTable: "users",
                principalColumn: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reasons_calls_reason_id",
                table: "reasons",
                column: "reason_id",
                principalTable: "calls",
                principalColumn: "call_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
