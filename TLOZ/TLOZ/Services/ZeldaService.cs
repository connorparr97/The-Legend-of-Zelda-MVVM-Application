using System;
using System.Collections.Generic;
using System.Text;
using TLOZ.Models;
using TLOZ.Services;

using System.Threading.Tasks; 

namespace TLOZ.Services
{
    public class ZeldaService
    {
        private readonly IRestService _restService;
        private readonly string _baseUrl;

        public ZeldaService(IRestService restService, string baseUrl)
        {
            _restService = restService;
            _baseUrl = baseUrl;
        }

        public async Task<GamesModel> GetAllGamesAsync()
        {
            var result = await _restService.GetAsync<GamesModel>($"{_baseUrl}games?limit=100");
            return result.payload; 
        }

        public async Task<SingleGameModel> GetGameAsync(string gameID)
        {
            var result = await _restService.GetAsync<SingleGameModel>($"{_baseUrl}games/{gameID}");

            return result.payload;
        }

        public async Task<CharactersModel> GetAllCharactersAsync(int limit, int page)
        {
            var result = await _restService.GetAsync<CharactersModel>($"{_baseUrl}/characters?limit={limit}&page={page}");

            return result.payload; 
        }
    }

}
