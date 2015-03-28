using System;
using HackDayDemo1.Services;
using PropertyChanged;
using System.Collections.Generic;
using HackDayDemo1.Models;
using Xamarin.Forms;

namespace HackDayDemo1.PageModels
{
    [ImplementPropertyChanged]
	public class ViewPersonPageModel : BasePageModel
	{
        public Person Person { get; set; }

        public override void Init (object initData)
        {
            Person = initData as Person;
        }

	}

}

