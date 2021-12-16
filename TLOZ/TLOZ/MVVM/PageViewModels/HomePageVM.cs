using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
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

            Task.Run(async () =>
            {
                System.Diagnostics.Debug.WriteLine("started");
                result = await _zeldaService.GetAllGamesAsync();
                System.Diagnostics.Debug.Write("got all games async");
                Result = result;
                CreateList();

                System.Diagnostics.Debug.Write("list created");
            });
        }
    


        public async Task GrabGames()
        {
            System.Diagnostics.Debug.WriteLine("started");
            result = await _zeldaService.GetAllGamesAsync();
            System.Diagnostics.Debug.Write("got all games async");
            Result = result;
            CreateList();

            System.Diagnostics.Debug.Write("list created");


        }

        public void CreateList()
        {
            System.Diagnostics.Debug.Write("creating list");
            
            foreach (var i in result.data) 
            {
                gamesList.Add(i);
                System.Diagnostics.Debug.WriteLine("added");

            }
        }





    }
}


