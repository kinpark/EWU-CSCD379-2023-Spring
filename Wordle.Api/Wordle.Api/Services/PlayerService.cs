using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        
        private readonly AppDbContext _db;

        public PlayerService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Player>> GetTopTen()
        {
            /*
            var count = 10;
            var totalCount = await _db.Players.CountAsync(player => player.AverageAttempts);
            totalCount -= count.Value;
            int index = totalCount.PlayerId;
            var topTen = await _db.Players
                .Where(player => player.AverageAttempts)
                .Skip(index)
                .Take(totalCount.Name, totalCount.AverageAttempts, totalCount.GameCount, totalCount.AverageSecondsPerGame)
                .OrderByDescending(p => p.AverageAttempts)
                .ToListAsync();
            return topTen;
            */

            var topTen = await _db.Players
                .OrderBy(p => p.AverageAttempts)
                .Take(10)
                .ToListAsync();
            return topTen;

        }
        
        public async Task<Player> AddPlayer(string newName, int playTime, int guesses)
        {
            if(newName == null) { throw new ArgumentException("Name can't be null"); }
            var player = await _db.Players.FirstOrDefaultAsync(p =>  p.Name == newName);
            if(player != null) 
            {
                player.GameCount++;
                player.TotalAttempts += guesses;
                player.AverageAttempts = player.TotalAttempts / player.GameCount;
                player.TotalSecondsPlayed += playTime;
                player.AverageSecondsPerGame = player.TotalSecondsPlayed / player.GameCount;
            }
            else
            {
                player = new()
                {
                    Name = newName,
                    GameCount = 1,
                    TotalAttempts = guesses,
                    AverageAttempts = 1,
                    TotalSecondsPlayed = playTime,
                    AverageSecondsPerGame = playTime
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

    }
}