using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameHistories",
                columns: table => new
                {
                    GameHistoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WinnerPlayerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameHistories", x => x.GameHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "GameHistoryPlayer",
                columns: table => new
                {
                    GameHistoriesGameHistoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    GamePlayersPlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameHistoryPlayer", x => new { x.GameHistoriesGameHistoryId, x.GamePlayersPlayerId });
                    table.ForeignKey(
                        name: "FK_GameHistoryPlayer_GameHistories_GameHistoriesGameHistoryId",
                        column: x => x.GameHistoriesGameHistoryId,
                        principalTable: "GameHistories",
                        principalColumn: "GameHistoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameHistoryPlayer_Players_GamePlayersPlayerId",
                        column: x => x.GamePlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameHistoryPlayer_GamePlayersPlayerId",
                table: "GameHistoryPlayer",
                column: "GamePlayersPlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameHistoryPlayer");

            migrationBuilder.DropTable(
                name: "GameHistories");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
