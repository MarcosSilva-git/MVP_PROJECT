using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVP.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ProcessingStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TicketStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Processing" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketStatus",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
