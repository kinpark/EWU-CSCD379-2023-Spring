﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly WordService _wordService;

        public WordController(WordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            Word word = await _wordService.GetRandomWord();
            return word.Text;
        }

        [HttpGet("GetManyWords")]
        public async Task<IEnumerable<Word>> GetManyWords(int? count)
        {
            return await _wordService.GetSeveralWords(count);
        }

        [HttpPost]
        public async Task<Word> AddWord(string newWord, bool isCommon)
        {
            return await _wordService.AddWord(newWord, isCommon);
        }

        [HttpPost("AddWordFromBody")]
        public async Task<Word> AddWordFromBody([FromBody] WordDto word)
        {
            return await _wordService.AddWord(word.Text, word.IsCommon);
        }

        [HttpGet("WordOfTheDay")]
        public async Task<string> GetWordOfTheDay(double offsetInHours, DateTime? date = null)
        {
            return await _wordService.GetWordOfTheDay(TimeSpan.FromHours(offsetInHours), date);
        }

        [HttpGet("GetDailyWordStatistics")]
        public async Task<List<WordOfTheDayStatsDto>> GetDailyWordStatistics(DateTime? date = null, int daysBack = 10, Guid? playerId = null)
        {
            return await _wordService.GetDailyWordStatistics(date, daysBack, playerId);
        }
    }
}    
