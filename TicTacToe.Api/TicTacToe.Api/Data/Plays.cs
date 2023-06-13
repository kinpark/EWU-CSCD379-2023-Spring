using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Data
{
    public class Plays
    {
        public int PlaysId { get; set; }
        public int PlayerId { get; set; }
        public required Player Player { get; set; }

        public int Moves { get; set; }
        public int TimeInSeconds { get; set; }
        public DateTime Date { get; set; }
        public bool WasGameWon { get; set; }
    }
}