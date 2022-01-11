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
    public class GamePageVM : MvvmZeroBaseVm, INotifyPropertyChanged
    {
        private readonly ZeldaService _zeldaService;

        private SingleGameModel _result;
        public ImageSource backgroundImage { get; set; }
        
        string _Title { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title
        {
            get { return _Title; }
            set { _Title = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                }
            }
        }


        public SingleGameModel Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public GamePageVM(ZeldaService zeldaService)
        {
            _zeldaService = zeldaService;

            backgroundImage = "https://external-preview.redd.it/9Enzn9tzmnNSRturLNyWm3_auqy74mcRYbbTdxoJqdk.jpg?auto=webp&s=30bcb2ef72e81ed10118dbeed1ba63ec39f5a3f0";
            
        }


        public void Init(SingleGameModel gameInfo)
        {
            Result = gameInfo;
            Title = $"{gameInfo.name} ({gameInfo.released_date})";
            System.Diagnostics.Debug.WriteLine($"{Title}");
        }

    }
}
