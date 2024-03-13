using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstLab.Migrations
{
    /// <inheritdoc />
    public partial class AnalyticsBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalyticsDays",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FlashcardSetsEdited = table.Column<int>(type: "INTEGER", nullable: false),
                    FlashcardSetsPlayed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticsDays", x => x.Date);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyticsDays");
        }
    }
}
