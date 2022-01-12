using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TLOZ.Models;
using TLOZ.MVVM.Pages;
using TLOZ.Services;
using Xamarin.Forms;

namespace TLOZ.MVVM.PageViewModels
{
    public class HomePageVM : MvvmZeroBaseVm
    {
        private GamesModel _gamesModel;
        public ICommand SearchCommand { get; }
        public ICommand GetGameCommand { get; }

        private readonly ZeldaService _zeldaService;
        private readonly IPageServiceZero _pageService;
        private ObservableCollection<GamesModel> _gamesList;
        private GamesModel _result;
        public GamesModel result;
        public ImageSource backgroundImage { get; set; }
        public GamesModel gamesModel
        {
            get => _gamesModel;
            set => SetProperty(ref _gamesModel, value);
        }
        public ObservableCollection<GamesModel> gamesList
        {
            get => _gamesList;
            set => SetProperty(ref _gamesList, value);
        }

        private SingleGameModel _GameResult;

        public GamesModel Item { get; set; }

        public SingleGameModel GameResult
        {
            get => _GameResult;
            set => SetProperty(ref _GameResult, value);
        }
        public GamesModel Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }
        private string _browser;
        public string Browser
        {
            get => _browser;
            set => SetProperty(ref _browser, value);
        }
        public IList<PickerModel> FilterList { get; set; }
        private PickerModel _selectedFilter;
        public PickerModel _currentSelectedFilter { get; set; }
        public PickerModel SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (_selectedFilter != value)
                {
                    {
                        _selectedFilter = value;
                        OnPropertyChanged();

                    }
                }
            }
        }
        public HomePageVM(ZeldaService zeldaService, IPageServiceZero pageService)
        {
            _zeldaService = zeldaService;
            _pageService = pageService;

            FilterList = new List<PickerModel>(new[]
            {
                new PickerModel {Filter = "ZeldaDungeon"}, //0
                new PickerModel {Filter = "ZeldaUniverse"}, //1
                new PickerModel {Filter = "Nintendolife"}, //2 
                new PickerModel {Filter = "PureZC"}, //3 
                new PickerModel {Filter = "ZeldaPalace"}, //4 
                new PickerModel {Filter = "ZeldaWiki"}, //5 
                new PickerModel {Filter = "Zeldapedia"}, //6 
                new PickerModel {Filter = "ZeldaClassic"}, //7
                new PickerModel {Filter = "ZeldaFanGameCentral"}, //8
                new PickerModel {Filter = "ZeldaReorchestrated"} //9 


            });
            SelectedFilter = FilterList[0];
            _currentSelectedFilter = SelectedFilter;

            gamesList = new ObservableCollection<GamesModel>();

            backgroundImage = "https://external-preview.redd.it/9Enzn9tzmnNSRturLNyWm3_auqy74mcRYbbTdxoJqdk.jpg?auto=webp&s=30bcb2ef72e81ed10118dbeed1ba63ec39f5a3f0"; //fetch background image for app from URL

            SearchCommand = new CommandBuilder().SetExecuteAsync(GrabGames).Build();
            GetGameCommand = new CommandBuilder().SetExecuteAsync(GetGame).Build();

            //alternate way to force an async to run on awake within a constructor 
            Exrin.Common.ThreadHelper.Init(SynchronizationContext.Current);
            Exrin.Common.ThreadHelper.RunOnUIThread(async () => { await GrabGames(); });

        }

        public async Task GetGame(object detailItem1)
        {
            GamesModel detailItem2 = detailItem1 as GamesModel;
            var gameID = detailItem2._id; 
            SingleGameModel gameResult; 
            gameResult = await _zeldaService.GetGameAsync(gameID);

            if (gameResult != null)
            { 
                GameResult = gameResult;          
                await _pageService.PushPageAsync<GamePage, GamePageVM>((vm) => vm.Init(GameResult.data));
            }
            else
                await GetGame(detailItem2);
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
                    if (gamesList.Count < Int32.Parse(result.count))
                        gamesList.Add(i);
                }
                CorrectMissingAPIInfo();
                gamesList.Remove(gamesList[16]);//remove triforce heroes copy from list 
                gamesList.Remove(gamesList[17]); //remove four swords copy from list
                gamesList.Remove(gamesList[18]); //remove four swords second copy fom list ;
                OrderGames();
            }
            else
                await GrabGames();
        }
        public void OrderGames()
        {
            ObservableCollection<GamesModel> tempList = new ObservableCollection<GamesModel>();
            tempList.Add(gamesList[0]);//0              
            tempList.Add(gamesList[6]);//1            
            tempList.Add(gamesList[1]);//2
            tempList.Add(gamesList[21]);//3
            tempList.Add(gamesList[19]);//4
            tempList.Add(gamesList[16]);//5
            tempList.Add(gamesList[26]);//6
            tempList.Add(gamesList[24]);//7
            tempList.Add(gamesList[11]);//8
            tempList.Add(gamesList[3]);//9
            tempList.Add(gamesList[4]);//10
            tempList.Add(gamesList[5]);//11
            tempList.Add(gamesList[2]);//12
            tempList.Add(gamesList[9]);//13
            tempList.Add(gamesList[7]);//14
            tempList.Add(gamesList[13]);//15
            tempList.Add(gamesList[17]);//16
            tempList.Add(gamesList[25]);//17
            tempList.Add(gamesList[8]);//18
            tempList.Add(gamesList[20]);//19
            tempList.Add(gamesList[10]);//20
            tempList.Add(gamesList[23]);//21
            tempList.Add(gamesList[22]);//22
            tempList.Add(gamesList[12]);//23
            tempList.Add(gamesList[15]);//24
            tempList.Add(gamesList[27]);//25
            tempList.Add(gamesList[14]);//26
            tempList.Add(gamesList[18]);//27
            gamesList.Clear();
            gamesList = tempList;
        }
        public void CorrectMissingAPIInfo() //api has missing dates and description for some results
                                            //and contains no image references for the video games 
        {
            foreach (var l in result.data)
            {
                if (l._id == "5f6ce9d805615a85623ec2b7") // ZELDA 1 (1987)
                    l.image = "https://upload.wikimedia.org/wikipedia/en/4/41/Legend_of_zelda_cover_%28with_cartridge%29_gold.png";

                if (l._id == "5f6ce9d805615a85623ec2b8") // LINK TO THE PAST
                    l.image = "https://m.media-amazon.com/images/M/MV5BMDNlYWY4NmEtNWUwOC00YWE1LWJhNzgtMzVhNDdkYTZhZGZhXkEyXkFqcGdeQXVyMTA3NjAwMDc4._V1_.jpg";

                if (l._id == "5f6ce9d805615a85623ec2b9") // ORACLE OF SEASONS
                    l.image = "https://www.mobygames.com/images/covers/l/7458-the-legend-of-zelda-oracle-of-ages-game-boy-color-front-cover.jpg";

                if (l._id == "5f6ce9d805615a85623ec2ba") // OCARINA OF TIME
                    l.image = "https://static.wikia.nocookie.net/nintendo/images/c/cd/Legend_of_Zelda_Ocarina_of_Time_%28NA%29.png/revision/latest?cb=20201223174539&path-prefix=en";

                if (l._id == "5f6ce9d805615a85623ec2bb") // LINKS AWAKENING DX
                    l.image = "https://static.wikia.nocookie.net/zelda_gamepedia_en/images/9/9a/LADX_NA_Box_Art.png/revision/latest?cb=20180907202228";

                if (l._id == "5f6ce9d805615a85623ec2bc") // MAJORAS MASK
                    l.image = "https://images.nintendolife.com/abb7470afc2c2/eu.original.jpg";

                if (l._id == "5f6ce9d805615a85623ec2bd") // ZELDA 2 ADVENTURE OF LINK
                    l.image = "https://www.mobygames.com/images/covers/l/14437-zelda-ii-the-adventure-of-link-nes-front-cover.jpg";

                if (l._id == "5f6ce9d805615a85623ec2bf") // WIND WAKER
                    l.image = "https://images.nintendolife.com/games/gamecube/legend_of_zelda_the_wind_waker/cover_large.jpg";

                if (l._id == "5f6ce9d805615a85623ec2be") // TWILIGHT PRINCESS
                    l.image = "https://riddle7.files.wordpress.com/2010/10/twilight_princess_gcn_us_boxart1.jpg";

                if (l._id == "5f6ce9d805615a85623ec2c0") // ORACLE OF SEASONS
                    l.image = "https://www.mobygames.com/images/covers/l/7392-the-legend-of-zelda-oracle-of-seasons-game-boy-color-front-cover.jpg";

                if (l._id == "5f6ce9d805615a85623ec2c5") //SPIRIT TRACKS
                {
                    l.image = "https://vgmsite.com/soundtracks/the-legend-of-zelda-spirit-tracks/zelda%20spirit%20tracks.jpg";
                    l.description = "Set a century after The Legend of Zelda: The Wind Waker and its sequel Phantom Hourglass, the storyline follows the current incarnations of Link and Princess Zelda as they explore the land of New Hyrule to prevent the awakening of the Demon King Malladus. Players navigate New Hyrule, completing quests that advance the story and solving environmental and dungeon-based puzzles, many requiring use of the DS's touchscreen and other hardware features. Navigation between towns and dungeons is done using a train, which features its own set of mechanics and puzzles.";
                }

                if (l._id == "5f6ce9d805615a85623ec2ca") // ANCIENT STONE TABLETS BS
                    l.image = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/d0a1a4f9-8ddb-48c6-9e55-2f60559d1f5b/ddlpi8i-edcbc171-466d-4fed-80a5-45d005fb144d.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2QwYTFhNGY5LThkZGItNDhjNi05ZTU1LTJmNjA1NTlkMWY1YlwvZGRscGk4aS1lZGNiYzE3MS00NjZkLTRmZWQtODBhNS00NWQwMDVmYjE0NGQucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.Qa4BF6WxjAMPirJMv8YLkyRJxH9MPkOPE70aY7tIULk";

                if (l._id == "5f6ce9d805615a85623ec2cf") // HYRULE WARRIORS
                    l.image = "https://art.gametdb.com/switch/coverHQ/US/AKUTB.jpg";

                if (l._id == "5f6ce9d805615a85623ec2c1") // FOUR SWORDS ADVENTURE
                    l.image = "https://m.media-amazon.com/images/I/51N2NRDX25L._AC_.jpg";

                if (l._id == "5f6ce9d805615a85623ec2c9") // BREATH OF THE WILD
                    l.image = "https://www.mobygames.com/images/covers/l/384053-the-legend-of-zelda-breath-of-the-wild-limited-edition-nintendo-switch-front-cover.jpg";

                if (l._id == "5f6ce9d805615a85623ec2d4") // TRIFORCE HEROES
                    l.image = "https://www.mobygames.com/images/covers/l/497181-the-legend-of-zelda-tri-force-heroes-nintendo-3ds-front-cover.jpg";

                if (l._id == "5f6ce9d805615a85623ec2d3") // WAND OF GAMELON
                    l.image = "https://www.mobygames.com/images/covers/l/71811-zelda-the-wand-of-gamelon-cd-i-front-cover.jpg";

                if (l._id == "5f6ce9d805615a85623ec2c6") // MINISH CAP
                    l.image = "https://static.wikia.nocookie.net/zelda_gamepedia_en/images/9/93/ZeldaMinishCap_BoxArt.jpg/revision/latest?cb=20100414213912";

                if (l._id == "5f6ce9d805615a85623ec2d0") // AGE OF CALAMITY - HYRULE WARRIORS 
                    l.image = "https://gamepreorders.com/wp-content/uploads/2020/09/cover-art-1.jpg";

                if (l._id == "5f6ce9d805615a85623ec2d5") // FACES OF EVIL
                    l.image = "https://m.media-amazon.com/images/M/MV5BMzExZWYzZDItNzM3Ny00ZjJhLTlhOTItZWZkNmI1OWMyMzAxXkEyXkFqcGdeQXVyNzg5OTk2OA@@._V1_FMjpg_UX1000_.jpg";

                if (l._id == "5f6ce9d805615a85623ec2c2") // PHANTOM HOURGLASS
                    l.image = "https://images.nintendolife.com/2f0d4cdbf1eed/legend-of-zelda-phantom-hourglass-cover.cover_large.jpg";

                if (l._id == "5f6ce9d805615a85623ec2c3") // LINKS AWAKENING
                    l.image = "https://www.mobygames.com/images/covers/l/172717-the-legend-of-zelda-link-s-awakening-game-boy-front-cover.jpg";

                if (l._id == "5f6ce9d805615a85623ec2c7") // A LINK BETWEEN WORLDS
                    l.image = "https://www.mobygames.com/images/covers/l/275323-the-legend-of-zelda-a-link-between-worlds-nintendo-3ds-front-cover.png";

                if (l._id == "5f6ce9d805615a85623ec2c8") // SKYWARD SWORD
                {
                    l.image = "https://i.redd.it/oaodpc51t5i61.jpg";
                    l.description = "Skyward Sword is the first game in the Zelda timeline detailing the origins of the Master Sword, a recurring weapon within the series. Link, " +
                        "resident of a floating town called Skyloft, heads on a quest to rescue his childhood friend Zelda after she is kidnapped and brought to the Surface, an abandoned land below the clouds.";
                }

                if (l._id == "5f6ce9d805615a85623ec2cc") // BS LEGEND OF ZELDAS
                    l.image = "https://i.ytimg.com/vi/KezI38G8qZs/hqdefault.jpg";

                if (l._id == "5f6ce9d805615a85623ec2cd") //FRESHLY PICKED TINGLE RUPEELAND 
                    l.image = "https://static.wikia.nocookie.net/zelda_gamepedia_en/images/8/81/FPTRR_UK_Box_Art.jpg/revision/latest?cb=20181118012256";

                if (l._id == "5f6ce9d805615a85623ec2d2") //ZELDAS ADVENTURE
                {
                    l.image = "https://1.bp.blogspot.com/-SqANJ-6THCM/YC9W2AwNNwI/AAAAAAAA4IY/y7Q-e9bnaHYzxMEWTeuXsU8dFmrFKaxMACLcBGAsYHQ/s411/zeldausa.png";
                    l.released_date = "June 5, 1994";
                }

                if (l._id == "5f6ce9d805615a85623ec2d1") //HYRULE WARRIORS LEGENDS
                    l.image = "https://images.nintendolife.com/5328a4eb7d9f0/hyrule-warriors-legends-cover.cover_large.jpg";

                if (l._id == "5f6ce9d805615a85623ec2d6") //LINKS CROSSBOW TRAINING
                    l.image = "https://www.mobygames.com/images/covers/l/98340-link-s-crossbow-training-wii-front-cover.jpg";
            }
        }

    }
}


