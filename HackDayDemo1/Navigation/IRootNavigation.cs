using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using HackDayDemo1.PageModels;

namespace HackDayDemo1.Navigation
{
    public interface IRootNavigation
    {
        void PushPage(Page page, BasePageModel model, bool modal = false);
        void PopPage(bool modal = false);
    }
}

