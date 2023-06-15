using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("GetTopTen")]
        public async Task<IEnumerable<Player>> GetTopTen()
        {
            return await _playerService.GetTopTen();
        }

        [HttpPost("AddPlayer")]
        public async Task<Player> AddPlayer(string newName, bool WonGame)
        {
            return await _playerService.AddPlayer(newName, WonGame);
        }

        [HttpPost("AddGameResult")]
        public async Task<Player?> AddGameResult(string Name, bool WasGameWon)
        {
             return await _playerService.AddGameResult(Name, WasGameWon);
        }

        [HttpGet("GetPlayer")]
        public async Task<Player> GetPlayer(String Name)
        {
            return await _playerService.GetPlayer(Name);
        }
    }
}