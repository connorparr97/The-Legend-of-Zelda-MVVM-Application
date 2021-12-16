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

        public async Task<GameInfoModel> GetGameDetails(string id)
        {
            var result = await _restService.GetAsync<GameInfoModel>($"{_baseUrl}games/{id}");
            return result.payload; 
        }

    }

}
