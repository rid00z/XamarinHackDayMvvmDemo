using System;
using System.Collections.Generic;
using HackDayDemo1.Models;

namespace HackDayDemo1.Services
{
    public interface IRemoteService
    {
        List<Person> GetPeople();
    }
}

