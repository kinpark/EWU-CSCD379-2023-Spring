namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public int GamesWon { get; set; }
        public double WinLossAverage { get; set; }
        public int TotalMoves { get; set; }
        public double AverageMoves { get; set; }
        public int TotalSecondsPlayed { get; set; }
        public int AverageSecondsPerGame { get; set; }

    }
}