using FunctionZero.MvvmZero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLOZ.MVVM.PageViewModels;

using System.Windows.Input;
using TLOZ.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TLOZ.MVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();
        }
        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(Dropdownpick.SelectedIndex == 0)
                webv.Source = "https://www.zeldadungeon.net/";
            if (Dropdownpick.SelectedIndex == 1)
                webv.Source = "https://zeldauniverse.net/";
            if (Dropdownpick.SelectedIndex == 2)
                webv.Source = "https://www.nintendolife.com/zelda";
        }
    }
}