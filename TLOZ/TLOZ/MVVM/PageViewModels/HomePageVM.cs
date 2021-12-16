using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TLOZ.Models;
using TLOZ.Services;


namespace TLOZ.MVVM.PageViewModels
{
    public class HomePageVM : MvvmZeroBaseVm
    {
        public GamesModel gamesModel { get; set; }

        private readonly ZeldaService _zeldaService;
        private readonly IPageServiceZero _pageService;
        private GamesModel _display;
        public ICommand SearchCommand { get; }
        public GamesModel Display
        {
            get => _display;
            set => SetProperty(ref _display, value);
        }

        public GamesModel item { get; set; }

        private ObservableCollection<GamesModel> _gamesList;
        public ObservableCollection<GamesModel> gamesList
        {
            get => _gamesList;
            set => SetProperty(ref _gamesList, value);
        }

        private string _name = "HATE THIS"; 

        public string name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }


        public string zName
        {
            get => _name;
            set => SetProperty(ref _name, value);
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

            SearchCommand = new CommandBuilder().SetExecuteAsync(SearchExecute).Build();
        }

        public async Task SearchExecute()
        {
            await GrabGames(); 
        }
        public async Task GrabGames()
        {
            result = await _zeldaService.GetAllGamesAsync();
            Result = result;
            CreateListAsync();

            
        }
        public async Task CreateListAsync()
        {
            zName = ":(";

            if (result != null)
            {
                foreach (var item in result.data)
                {
                    gamesList.Add(result);
                    zName = item.name;



                }
            }
            else
            {
                await GrabGames(); 
            }

        }






    }


}
