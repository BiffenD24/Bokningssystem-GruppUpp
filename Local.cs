using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_GruppUpp
{
    internal class Local
    {
        // gemensamma metoder och egenskaper. 1:Namn på rummet, Storlek, Maxtid för bokning, kapacitet




         

        //Metod som skriver ut alla bokningar. *Moses gjort.  
        public void PrintBookings() 
        {
            Console.Clear();
            Console.Write("NEDAN ÄR DINA BOKNINGAR");
            foreach (Local allBookings in bookingList)
            {
                Console.Write(allBookings);   
            }
            Console.Write("\n\n\t\t\tTryck valfri knapp för att fortsätta...");
            Console.ReadKey();

        }

        public static List<Local> bookingList = new List<Local>(); //Bokningslista för alla bokningar.

    }
}
