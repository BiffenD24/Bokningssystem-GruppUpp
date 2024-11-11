using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_GruppUpp
{
    internal interface IBookable
    {
        //OBS! Måste vara statiska för menyn att komma åt de. 
        static void NewBookable() { }

        static void PrintBookings() { }

        static void UpdateBooking() { }

        static void RemoveBooking() { }

        static void SortByYear(){ }


        //OBS! Måste ha propeties här också.  
        public string? Name { get; set; }
        public string? Room { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public TimeSpan LengthOfBooking { get; set; } 

    }
}
