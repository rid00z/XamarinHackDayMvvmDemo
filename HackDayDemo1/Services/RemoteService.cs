using System;
using System.Collections.Generic;
using HackDayDemo1.Models;

namespace HackDayDemo1.Services
{
    public class RemoteService : IRemoteService
    {
        public RemoteService ()
        {
        }

        public List<Person> GetPeople()
        {
            return new List<Person> 
            { 
                new Person { FirstName = "Peter", Surname = "Green", Age = 35 },
                new Person { FirstName = "Michael", Surname = "Ridland", Age = 32 },
                new Person { FirstName = "Xam", Surname = "Consulting", Age = 1 }
            };
        }
    }
}

