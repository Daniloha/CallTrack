using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallTrack.Data.Migrations
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
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    UsersUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managers", x => x.manager_id);
                    table.ForeignKey(
                        name: "FK_managers_users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "users",
                        principalColumn: "user_id");
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
                    ManagersManagerId = table.Column<long>(type: "bigint", nullable: true),
                    UsersUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analysts", x => x.analyst_id);
                    table.ForeignKey(
                        name: "FK_analysts_managers_ManagersManagerId",
                        column: x => x.ManagersManagerId,
                        principalTable: "managers",
                        principalColumn: "manager_id");
                    table.ForeignKey(
                        name: "FK_analysts_users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "users",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "calls",
                columns: table => new
                {
                    call_id = table.Column<long>(type: "bigint", nullable: false),
                    call_observation = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    close_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    open_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    call_type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    call_code = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    call_status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calls", x => x.call_id);
                    table.ForeignKey(
                        name: "FK_calls_analysts_call_id",
                        column: x => x.call_id,
                        principalTable: "analysts",
                        principalColumn: "analyst_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reasons",
                columns: table => new
                {
                    reason_id = table.Column<long>(type: "bigint", nullable: false),
                    reason_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("reason_id", x => x.reason_id);
                    table.ForeignKey(
                        name: "FK_reasons_calls_reason_id",
                        column: x => x.reason_id,
                        principalTable: "calls",
                        principalColumn: "call_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_analysts_ManagersManagerId",
                table: "analysts",
                column: "ManagersManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_analysts_UsersUserId",
                table: "analysts",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_managers_UsersUserId",
                table: "managers",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reasons");

            migrationBuilder.DropTable(
                name: "calls");

            migrationBuilder.DropTable(
                name: "analysts");

            migrationBuilder.DropTable(
                name: "managers");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
