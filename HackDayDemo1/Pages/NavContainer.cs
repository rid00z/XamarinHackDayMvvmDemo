using System;
using HackDayDemo1.Navigation;
using Xamarin.Forms;
using HackDayDemo1.PageModels;

namespace HackDayDemo1.Pages
{
    public class NavContainer : NavigationPage, IRootNavigation
    {
        public NavContainer (Page page) : base(page)
        {
        }

        protected override async void OnAppearing ()
        {
            base.OnAppearing ();

        }

        public void PushPage (Xamarin.Forms.Page page, BasePageModel model, bool modal = false)
        {
            if (modal)
                this.Navigation.PushModalAsync (page);
            else
                this.Navigation.PushAsync (page);
        }

        public void PopPage (bool modal = false)
        {
            if (modal)
                this.Navigation.PopModalAsync ();
            else
                this.Navigation.PopAsync();
        }
    }
}

