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
using TLOZ.Services;
using Xamarin.Forms;
namespace TLOZ.MVVM.PageViewModels
{
    public class GamePageVM : MvvmZeroBaseVm
    {
        private GamesModel _gamesModel;

        private readonly ZeldaService _zeldaService;
        private readonly IPageServiceZero _pageService;

        private GamesModel _display;

        private GamesModel _result;
        public GamesModel result; 
        public ImageSource backgroundImage { get; set; }

        public GamesModel gamesModel
        {
            get => _gamesModel;
            set => SetProperty(ref _gamesModel, value);
        }

        public GamesModel Display
        {
            get => _display;
            set => SetProperty(ref _display, value);
        }

        public GamePageVM(ZeldaService zeldaService, IPageServiceZero pageService)
        {
            _zeldaService = zeldaService;
            _pageService = pageService;

            backgroundImage = "https://external-preview.redd.it/9Enzn9tzmnNSRturLNyWm3_auqy74mcRYbbTdxoJqdk.jpg?auto=webp&s=30bcb2ef72e81ed10118dbeed1ba63ec39f5a3f0";
        }

    }
}
