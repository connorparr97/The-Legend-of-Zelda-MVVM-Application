using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TLOZ.Models;
using TLOZ.Services;


namespace TLOZ.MVVM.PageViewModels
{
    public class HomePageVM : MvvmZeroBaseVm
    {
        private GamesModel _gamesModel; 
        public GamesModel gamesModel
        {
            get => _gamesModel;
            set => SetProperty(ref _gamesModel, value);
        }

        private readonly ZeldaService _zeldaService;
        private readonly IPageServiceZero _pageService;
        private GamesModel _display;
        public ICommand SearchCommand { get; }
        public GamesModel Display
        {
            get => _display;
            set => SetProperty(ref _display, value);
        }


        private ObservableCollection<GamesModel> _gamesList;
        public ObservableCollection<GamesModel> gamesList
        {
            get => _gamesList;
            set => SetProperty(ref _gamesList, value);
        }

        private GamesModel _result;

        public GamesModel result;
        public GamesModel Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public HomePageVM(ZeldaService zeldaService, IPageServiceZero pageService)
        {
            _zeldaService = zeldaService;
            _pageService = pageService;

            gamesList = new ObservableCollection<GamesModel>();

            SearchCommand = new CommandBuilder().SetExecuteAsync(GrabGames).Build();

            Exrin.Common.ThreadHelper.Init(SynchronizationContext.Current);
            Exrin.Common.ThreadHelper.RunOnUIThread(async () => { await GrabGames(); });
        }




        public async Task GrabGames()
        {
 
            result = await _zeldaService.GetAllGamesAsync();
            
            Result = result;

            if (result != null)
            {
                foreach (var i in result.data)
                {
                    var tmp = i.released_date.TrimStart();
                    i.released_date = tmp; 
                    System.Diagnostics.Debug.Write($"date:{i.released_date}");
                    gamesList.Add(i);

                }
            }
            else
                await GrabGames(); 



        }







    }
}


