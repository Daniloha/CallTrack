using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUpdateInitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "openDate",
                table: "calls",
                newName: "call_open_date");

            migrationBuilder.RenameColumn(
                name: "closeDate",
                table: "calls",
                newName: "call_close_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "call_open_date",
                table: "calls",
                newName: "openDate");

            migrationBuilder.RenameColumn(
                name: "call_close_date",
                table: "calls",
                newName: "closeDate");
        }
    }
}
