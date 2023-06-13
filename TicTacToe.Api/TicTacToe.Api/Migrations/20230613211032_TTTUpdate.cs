using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe.Api.Migrations
{
    /// <inheritdoc />
    public partial class TTTUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plays_DateWords_DateWordId",
                table: "Plays");

            migrationBuilder.DropForeignKey(
                name: "FK_Plays_Words_WordId",
                table: "Plays");

            migrationBuilder.DropTable(
                name: "DateWords");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Plays_DateWordId",
                table: "Plays");

            migrationBuilder.DropIndex(
                name: "IX_Plays_WordId",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "DateWordId",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "Plays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DateWordId",
                table: "Plays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WordId",
                table: "Plays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCommon = table.Column<bool>(type: "bit", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.CreateTable(
                name: "DateWords",
                columns: table => new
                {
                    DateWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateWords", x => x.DateWordId);
                    table.ForeignKey(
                        name: "FK_DateWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plays_DateWordId",
                table: "Plays",
                column: "DateWordId");

            migrationBuilder.CreateIndex(
                name: "IX_Plays_WordId",
                table: "Plays",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_DateWords_WordId",
                table: "DateWords",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plays_DateWords_DateWordId",
                table: "Plays",
                column: "DateWordId",
                principalTable: "DateWords",
                principalColumn: "DateWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plays_Words_WordId",
                table: "Plays",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "WordId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
