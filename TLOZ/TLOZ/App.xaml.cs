using System;
using TLOZ.MVVM.Boilerplate;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TLOZ.MVVM.PageViewModels;
using System.Threading.Tasks;
using TLOZ.Services;
[assembly: ExportFont("Zeldafont.otf", Alias = "Zeldafont")]
[assembly: ExportFont("BotwFont.otf", Alias = "Botwfont")]
[assembly: ExportFont("WindwakerFont.ttf", Alias = "Windwakerfont")]
[assembly: ExportFont("Windwaker2Font.ttf", Alias = "Windwaker2font")]

namespace TLOZ
{
    
    public partial class App : Application
    {
        public Locator Locator { get; private set;}





        public App()
        {


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
