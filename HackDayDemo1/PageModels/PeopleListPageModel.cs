using System;
using HackDayDemo1.Services;
using PropertyChanged;
using System.Collections.Generic;
using HackDayDemo1.Models;
using Xamarin.Forms;

namespace HackDayDemo1.PageModels
{
    [ImplementPropertyChanged]
    public class PeopleListPageModel : BasePageModel
    {
        IRemoteService _remoteService;
        public List<Person> PeopleList { get; set; }

        public PeopleListPageModel (IRemoteService remoteService)
        {
            _remoteService = remoteService;
        }

        public override void Init (object initData)
        {
            PeopleList = _remoteService.GetPeople ();
        }

//        protected override void HandleAppearing (object sender, EventArgs e)
//        {
//        }

        public Person SelectedPerson
        {
            set {
                if (value != null)
                    PersonSelected.Execute (value);
            }
        }

        public Command PersonSelected
        {
            get { 
                return new Command ((person) => {
                    PushPageModel<ViewPersonPageModel> (person);
                });
            }
        }

    }
}

