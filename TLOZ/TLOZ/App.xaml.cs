using System;
using TLOZ.MVVM.Boilerplate;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TLOZ.MVVM.PageViewModels;
using System.Threading.Tasks;
using TLOZ.Services;
using Windows.UI.ViewManagement;
using Windows.Graphics.Display;
[assembly: ExportFont("Zeldafont.otf", Alias = "Zeldafont")]
[assembly: ExportFont("BotwFont.otf", Alias = "Botwfont")]
[assembly: ExportFont("WindwakerFont.ttf", Alias = "Windwakerfont")]
[assembly: ExportFont("Windwaker2Font.ttf", Alias = "Windwaker2font")]
[assembly: ExportFont("OpenSansItalic.ttf", Alias = "OpenSansItalic")]
[assembly: ExportFont("OpenSansVariable.ttf", Alias = "OpenSansVariable")]

namespace TLOZ
{
    public partial class App : Application
    {
        public Locator Locator { get; private set;}

        public App()
        {
            //force fullscreen if possible
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.Maximized;

            InitializeComponent();

            // Create our Locator instance and tell it about the Application instance ...
            Locator = new Locator(this);

            // Ask the Locator to get us going ...
            _ = Locator.SetFirstPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


    }
}
