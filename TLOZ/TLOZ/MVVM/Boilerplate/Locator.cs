using FunctionZero.MvvmZero;
using SimpleInjector;
using TLOZ.MVVM.Pages;
using TLOZ.MVVM.PageViewModels;
using TLOZ.Models; 
using TLOZ.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TLOZ.MVVM.Boilerplate
{
    public class Locator
    {
        private Container _iocc;
        
        public Locator(Application currentApplication)
        {
            _iocc = new Container();

            _iocc.Register<IPageServiceZero>(
                () =>
                {
                    var pageService = new PageServiceZero(() => App.Current.MainPage.Navigation, (theType) => _iocc.GetInstance(theType));
                    return pageService; 
                }, Lifestyle.Singleton
            );

            //pages 
            _iocc.Register<HomePage>(Lifestyle.Singleton);

            //viewmodels
            _iocc.Register<HomePageVM>(Lifestyle.Singleton); 

            //services
            _iocc.Register<IRestService>(GetRestService, Lifestyle.Singleton);
            _iocc.Register<ZeldaService>(GetZeldaService, Lifestyle.Singleton);
        }

        private ZeldaService GetZeldaService()
        {
            return new ZeldaService(_iocc.GetInstance<IRestService>(), ApiConstants.baseUrl);
        }

        private IRestService GetRestService()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); 
            return new RestService(httpClient);
        }

        internal async Task SetFirstPage()
        {
            App.Current.MainPage = new NavigationPage(); 
            await _iocc.GetInstance<IPageServiceZero>().PushPageAsync<HomePage, HomePageVM>((vm) => { }); 
        }
    }
}
