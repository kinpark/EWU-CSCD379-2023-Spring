using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Controllers;
using Microsoft.EntityFrameworkCore.Query;

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

            var topTen = await _db.Players
                .OrderBy(p => p.WinLossAverage)
                .ThenByDescending(p => p.GameCount)
                .Take(10)
                .ToListAsync();
            return topTen;

        }
        
        public async Task<Player> AddPlayer(string Name, bool WonGame)
        {
            if(Name == null) { throw new ArgumentException("Name can't be null"); }

            if(Name == "Guest")
            {
                Player guest = new()
                {
                    Name = Name,
                    GameCount = 0,
                    GamesWon = 0,
                    WinLossAverage = 0,
                };

                return guest;
            }

            var player = await _db.Players.FirstOrDefaultAsync(p =>  p.Name == Name);
            if (player != null)
            {
                player.GameCount++;

                if (WonGame)
                    player.GamesWon++;

                player.WinLossAverage = player.GamesWon / player.GameCount;
            }
            else
            {
                if (WonGame) 
                { 
                    player = new()
                    {
                        Name = Name,
                        GameCount = 1,
                        GamesWon = 1,
                        WinLossAverage = 1,
                    };
                }
                else
                {
                    player = new()
                    {
                        Name = Name,
                        GameCount = 1,
                        GamesWon = 0,
                        WinLossAverage = 0,
                    };
                }
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;
        }

        
        public async Task<Player?> GetAsync(int playerId)
        {
            return await _db.Players
                .Where(p => p.PlayerId == playerId)
                .FirstOrDefaultAsync();
        }

        public async Task<Player> CreateAsync(string name)
        {
            Player player = new()
            {
                Name = name,
                //PlayerId = Guid.NewGuid()
            };
            _db.Players.Add(player);
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<Player> UpdateAsync(int playerId, string name)
        {
            var player = await _db.Players.FindAsync(playerId);
            if (player is not null)
            {
                player.Name = name;
                await _db.SaveChangesAsync();
                return player;
            }
            throw new ArgumentException("Player Id not found");
        }
        

        public async Task<Player?> AddGameResult(string Name, bool WasGameWon)
        {
            await AddPlayer(Name, WasGameWon);
            var player = await _db.Players.FirstOrDefaultAsync(n => n.Name == Name);

                if (player is not null)
                {

                    Plays play = new()
                    {
                        Player = player,
                        WasGameWon = WasGameWon,
                    };

                    _db.Plays.Add(play);
                    await _db.SaveChangesAsync();
                    
                    //return play;
                }

            return player;
            throw new ArgumentException("Player Id or Word not found");
        }

        public async Task<Player> GetPlayer(String Name)
        {
            if (Name == null) { throw new ArgumentException("Name can't be null"); }
            var player = await _db.Players.FirstOrDefaultAsync(p => p.Name == Name);
            if(player != null)
            {
                return player;
            }
            else { throw new ArgumentException("Name must be in the database"); }
        }
    }
}
