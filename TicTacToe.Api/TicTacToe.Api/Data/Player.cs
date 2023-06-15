using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{
     public class Player
    {
        public int PlayerId {  get; set; }
        public required string Name { get; set; }
        public int GameCount { get; set; }
        public int GamesWon { get; set; }
        public double WinLossAverage { get; set; }

        public static void SeedPlayers(AppDbContext db)
        {
            if (!db.Players.Any())
            {
                var playerLines = System.IO.File.ReadAllLines("Content/Players.csv");
                foreach (var line in playerLines)
                {
                    var parts = line.Split(',');
                    var player = new Player()
                    {
                        Name = parts[0],
                        GameCount = int.Parse(parts[1]),
                        GamesWon = int.Parse(parts[2]),
                    };
                    player.WinLossAverage = (player.GamesWon / player.GameCount)*100;
                    db.Players.Add(player);
                }
                db.SaveChanges();
            }

        }
    }
}