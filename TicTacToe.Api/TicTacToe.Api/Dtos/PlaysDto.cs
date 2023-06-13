namespace Wordle.Api.Dtos
{
    public class PlaysDto
    {
        public int PlayerId { get; set; }
        public bool WasGameWon { get; set; }
        public int Moves { get; set; }
        public int TimeInSeconds { get; set; }
    }
}
