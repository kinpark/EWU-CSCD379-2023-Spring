using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMovesTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attempts",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "TimeInSeconds",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "AverageSecondsPerGame",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TotalAttempts",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AverageSecondsPerGame",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TotalSecondsPlayed",
                table: "Players",
                newName: "GamesWon");

            migrationBuilder.RenameColumn(
                name: "AverageAttempts",
                table: "Players",
                newName: "WinLossAverage");

            migrationBuilder.RenameColumn(
                name: "AverageAttempts",
                table: "AspNetUsers",
                newName: "WinLossAverage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WinLossAverage",
                table: "Players",
                newName: "AverageAttempts");

            migrationBuilder.RenameColumn(
                name: "GamesWon",
                table: "Players",
                newName: "TotalSecondsPlayed");

            migrationBuilder.RenameColumn(
                name: "WinLossAverage",
                table: "AspNetUsers",
                newName: "AverageAttempts");

            migrationBuilder.AddColumn<int>(
                name: "Attempts",
                table: "Plays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeInSeconds",
                table: "Plays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AverageSecondsPerGame",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAttempts",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AverageSecondsPerGame",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
