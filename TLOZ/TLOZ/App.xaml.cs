using System;
using TLOZ.MVVM.Boilerplate;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TLOZ.MVVM.PageViewModels;
using System.Threading.Tasks;
using TLOZ.Services;

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

        protected override async void OnStart()
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
