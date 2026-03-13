using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WellbeingTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    rec_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stress_range = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recommendation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.rec_id);
                });

            migrationBuilder.CreateTable(
                name: "WellbeingLogs",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stress_level = table.Column<int>(type: "int", nullable: false),
                    sleep_hours = table.Column<double>(type: "float", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellbeingLogs", x => x.log_id);
                });

            migrationBuilder.InsertData(
                table: "Recommendations",
                columns: new[] { "rec_id", "recommendation", "stress_range" },
                values: new object[,]
                {
                    { 1, "Suggest productivity or mindfulness tips", "0-3" },
                    { 2, "Suggest physical activity or short breaks", "4-7" },
                    { 3, "Suggest breathing or relaxation exercises", "8-10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "WellbeingLogs");
        }
    }
}
