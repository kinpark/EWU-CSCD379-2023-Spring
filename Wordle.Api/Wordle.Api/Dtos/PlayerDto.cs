namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public int GamesWon { get; set; }
        public double WinLossAverage { get; set; }

    }
}