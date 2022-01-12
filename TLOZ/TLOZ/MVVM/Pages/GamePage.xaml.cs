using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TLOZ.MVVM.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
        }
        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Dropdownpick.SelectedIndex == 0)
                webv.Source = "https://www.zeldadungeon.net/";
            if (Dropdownpick.SelectedIndex == 1)
                webv.Source = "https://zeldauniverse.net/";
            if (Dropdownpick.SelectedIndex == 2)
                webv.Source = "https://www.nintendolife.com/zelda";
            if (Dropdownpick.SelectedIndex == 3)
                webv.Source = "https://www.purezc.net/";
            if (Dropdownpick.SelectedIndex == 4)
                webv.Source = "https://www.zeldaspalace.com/";
            if (Dropdownpick.SelectedIndex == 5)
                webv.Source = "https://zelda.fandom.com/wiki/Main_Page";
            if (Dropdownpick.SelectedIndex == 6)
                webv.Source = "https://zelda-archive.fandom.com/wiki/Zeldapedia";
            if (Dropdownpick.SelectedIndex == 7)
                webv.Source = "https://www.zeldaclassic.com/";
            if (Dropdownpick.SelectedIndex == 8)
                webv.Source = "http://zfgc.com/forum/index.php";
            if (Dropdownpick.SelectedIndex == 9)
                webv.Source = "http://zreomusic.com/";

        }
    }
}