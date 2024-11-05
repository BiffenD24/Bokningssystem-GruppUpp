using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_GruppUpp
{
    internal interface IBookable
    {
        void NewBookable();
        void PrintBookings();
        void UpdateBooking();
        void RemoveBooking();
        void SortByYear();
    }
}
