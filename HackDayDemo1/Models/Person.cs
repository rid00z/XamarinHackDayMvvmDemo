using System;
using PropertyChanged;

namespace HackDayDemo1.Models
{
    [ImplementPropertyChanged]
    public class Person
    {
        public Person ()
        {
        }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}

