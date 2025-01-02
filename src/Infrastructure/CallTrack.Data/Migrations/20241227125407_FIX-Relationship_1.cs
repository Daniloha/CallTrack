using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class FIXRelationship_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_calls_analysts_AnalystId1",
                table: "calls");

            migrationBuilder.DropForeignKey(
                name: "FK_managers_users_UserId",
                table: "managers");

            migrationBuilder.DropIndex(
                name: "IX_calls_AnalystId1",
                table: "calls");

            migrationBuilder.DropColumn(
                name: "AnalystId1",
                table: "calls");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "users",
                newName: "manager_id");

            migrationBuilder.RenameColumn(
                name: "AnalystId",
                table: "users",
                newName: "analyst_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "managers",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_managers_UserId",
                table: "managers",
                newName: "IX_managers_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_managers_users_user_id",
                table: "managers",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_managers_users_user_id",
                table: "managers");

            migrationBuilder.RenameColumn(
                name: "manager_id",
                table: "users",
                newName: "ManagerId");

            migrationBuilder.RenameColumn(
                name: "analyst_id",
                table: "users",
                newName: "AnalystId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "managers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_managers_user_id",
                table: "managers",
                newName: "IX_managers_UserId");

            migrationBuilder.AddColumn<long>(
                name: "AnalystId1",
                table: "calls",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_calls_AnalystId1",
                table: "calls",
                column: "AnalystId1");

            migrationBuilder.AddForeignKey(
                name: "FK_calls_analysts_AnalystId1",
                table: "calls",
                column: "AnalystId1",
                principalTable: "analysts",
                principalColumn: "analyst_id");

            migrationBuilder.AddForeignKey(
                name: "FK_managers_users_UserId",
                table: "managers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
