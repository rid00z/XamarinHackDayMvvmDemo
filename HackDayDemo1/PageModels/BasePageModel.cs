using System;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using HackDayDemo1.Navigation;
using System.Runtime.CompilerServices;

namespace HackDayDemo1.PageModels
{
    public enum LoadingType { None, Page, FullScreen }

    [PropertyChanged.ImplementPropertyChanged]
    public abstract class BasePageModel : INotifyPropertyChanged
    {
        public string Alert { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public BasePageModel PreviousPageModel { get; set; }
        public LoadingType LoadingStatus { get; set; }
        public double CalcdWidth { get; set; }

        public virtual void ReverseInit(object value) { }

        public virtual void Init(object initData) { }

        protected void PushPageModel<T>() where T : BasePageModel
        {
            PushPageModel<T>(null);
        }

        public static Page ResolvePageModel<T>(object initData)
            where T : BasePageModel
        {
            var pageModel = TinyIoC.TinyIoCContainer.Current.Resolve<T>();

            return ResolvePageModel<T>(initData, pageModel);
        }

        public static Page ResolvePageModel<T>(object data, BasePageModel pageModel)
            where T : BasePageModel
        {
            var name = typeof(T).Name.Replace("Model", string.Empty);
            var pageType = Type.GetType("HackDayDemo1.Pages." + name);
            if (pageType == null)
                throw new Exception("Type HackDayDemo1.Pages." + name + " not found");

            var page = (Page)TinyIoC.TinyIoCContainer.Current.Resolve(pageType); //does constructor injection

            page.BindingContext = pageModel;
            pageModel.WireEvents(page);

            pageModel.Init(data); // Call the init

            page.BindingContext = pageModel; //set the binding context

            return page;
        }

        protected async Task PushPageModel<T>(object data, bool modal = false) where T : BasePageModel
        {
            BasePageModel pageModel = TinyIoC.TinyIoCContainer.Current.Resolve<T>(); ;

            var page = ResolvePageModel<T>(data, pageModel);

            pageModel.PreviousPageModel = this;

            IRootNavigation rootNav = TinyIoC.TinyIoCContainer.Current.Resolve<IRootNavigation>();
            if (!modal)
            {
                rootNav.PushPage(page, pageModel, modal);
            }
            else
            {
                var navContainer = new NavigationPage(page);
                rootNav.PushPage(navContainer, pageModel, modal);
            }
        }

        protected void PopPageModel(bool modal = false)
        {
            IRootNavigation rootNav = TinyIoC.TinyIoCContainer.Current.Resolve<IRootNavigation>();
            rootNav.PopPage(modal);
        }

        protected void PopPageModel(object data, bool modal = false)
        {
            if (PreviousPageModel != null && data != null)
            {
                var initMethod = TinyIoC.TypeExtensions.GetMethod(PreviousPageModel.GetType(), "ReverseInit");
                if (initMethod != null)
                {
                    initMethod.Invoke(PreviousPageModel, new object[] { data });
                }
            }
            IRootNavigation tabbedNav = TinyIoC.TinyIoCContainer.Current.Resolve<IRootNavigation>();
            tabbedNav.PopPage(modal);
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void WireEvents(Page page)
        {
            page.Appearing += HandleAppearing;
        }

        protected virtual void HandleAppearing (object sender, EventArgs e)
        {

        }



        //        public Command Search {
        //            get {
        //                return new Command((o) =>
        //                    {
        //                        PushPageModel<CompanySearchPageModel>(null, true);
        //                    });
        //            }
        //        }
        //
        //        public Command CloseModal {
        //            get { 
        //                return new Command((o) =>
        //                    {
        //                        IRootNavigation rootNav = TinyIoC.TinyIoCContainer.Current.Resolve<IRootNavigation>();
        //                        rootNav.PopPage(true);
        //                    });
        //            }
        //        }
    }
}

