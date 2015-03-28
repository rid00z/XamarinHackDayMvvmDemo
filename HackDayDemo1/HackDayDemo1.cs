using System;

using Xamarin.Forms;
using HackDayDemo1.PageModels;
using HackDayDemo1.Services;
using HackDayDemo1.Pages;
using HackDayDemo1.Navigation;
using System.Threading.Tasks;

namespace HackDayDemo1
{
    public class App : Application
    {
        public App ()
        {
            SetupIOC ();
            var firstPage = BasePageModel.ResolvePageModel<PeopleListPageModel>(null);
            var mainNav = new NavContainer (firstPage);
            TinyIoC.TinyIoCContainer.Current.Register<IRootNavigation> (mainNav);
            MainPage = mainNav;
        }

        void SetupIOC()
        {
            TinyIoC.TinyIoCContainer.Current.Register<IRemoteService, RemoteService> ();
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}

