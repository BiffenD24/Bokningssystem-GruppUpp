using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_GruppUpp
{
    public class Local : IBookable
    {
        // properties för att spara bokningarna
        public string? Name { get; set; }
        public string? Room { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public TimeSpan LengthOfBooking { get; set; }

        // lista av bokningarna
        public List<Local> BookingList = new List<Local>();
        // konstruktor som tar in värden från användaren
        public Local(string name, string room, DateTime from, DateTime to, TimeSpan length)
        {
            Name = name;
            Room = room;
            From = from;
            To = to;
            LengthOfBooking = length;
        }
        
        public Local()
        {

        }
        // lista för rummen som vi kommer skapa senare, kan ta bort den men använde för att testa koden
        public static List<Local> Rooms = new List<Local>();
        // Egenskaper för dom skapade salar och grupprum
        public string? Roomscreated { get; set; }
        public double? MaxTime { get; set; }
        public int? Capacity { get; set; }
        // konstruktor för att skapa rum senare
        public Local(string roomscreated,double maxTime,int capacity)
        {
            Roomscreated = roomscreated;
            MaxTime = maxTime;
            Capacity = capacity;
        }

        // Metod för att göra ny bokning * Dennis gjort
        public void NewBookable()
        {
            // loop för att hålla igång programmet tills användaren har angivit rätt uppgifter
            while (true)
            {
                Console.Clear();           
                // välkommnar användaren
                Console.WriteLine("Välkommen till att boka sal/grupprum");
                // ber användaren skriva in sitt namn och sparar det i en string variabel
                Console.WriteLine("Ange ditt namn");
                string name = Console.ReadLine() ?? "";
                // kollar om strängen är tom eller null
                if (string.IsNullOrEmpty(name))
                {
                    // om den är null eller tom kommer det skrivas ut ett felmeddelande och användaren får börja om
                    Console.WriteLine("Felaktigt svar, försök igen\nTryck valfri knapp för att gå tillbaka");
                    Console.ReadLine();
                    continue;
                }

                // ber användaren ange sal eller grupprum och sparar det i en sträng
                Console.WriteLine("Vilken sal/grupprum vill du boka?");
                string room = Console.ReadLine() ?? "";
                // Kollar att rummet finns i listan
                var roomFound = Rooms.FirstOrDefault(a => a.Roomscreated == room);
                // om variabeln är null kommer användaren få ett felmeddelande och börja om
                if (roomFound == null)
                {
                    Console.WriteLine("Salen eller grupprummet existerar inte, försök igen\nTryck valfri knapp för att gå tillbaka");
                    Console.ReadLine();
                    // går tillbaka till början av loopen
                    continue;
                }

                // ber användaren om start-tid för bokningen och ber den använda rätt format
                Console.WriteLine("Från vilket datum vill du boka salen/grupprummet?\nAnge i detta format År/Månad/Dag Timme:Minut");
                // sparar det i en bool variabel och försöker parsa inputen. Om parsningen lyckas kommer den skicka ut Datetime from.
                var fromdate = DateTime.TryParse(Console.ReadLine(), out DateTime from);
                // om parsningen inte lyckas kommer bool bli false och användaren kommer få ett felmeddelande och få börja om
                if (fromdate == false)
                {
                    Console.WriteLine("Felaktigt format, försök igen\nTryck enter för att gå tillbaka");
                    Console.ReadLine();
                    continue;
                }

                // ber användaren att ange längden på bokningen och sparar det i en bool
                Console.WriteLine("Hur länge önskar du boka?\nAnge i detta format År/Månad/Dag Timme:Minut");
                var todate = DateTime.TryParse(Console.ReadLine(), out DateTime to);
                // om parsningen inte går igenom kommer bool bli false och användaren får ett felmeddelande och får börja om
                if (todate == false)
                {
                    Console.WriteLine("Felaktigt format, försök igen\nTryck valfri knapp för att gå tillbaka");
                    Console.ReadLine();
                    continue;
                }
                // beräknar längden på bokningen och sparar det.
                TimeSpan length = to - from;

                // if-sats för att kolla om det redan finns en bokning på samma rum och tid. Om det finns det kommer användaren få ett felmeddelande och börja om bokningen
                if (BookingList.Any(b => b.Room == room && (from < b.To && to > b.From)))
                {
                    Console.WriteLine("Rummet är bokat på din önskade tid\nTryck valfri knapp för att börja om");
                    Console.ReadLine();
                    continue;
                }
                // annars om det inte finns en bokad tid kommer denna kod köras
                else
                {
                    // Lägger till i listan för bokningar
                    BookingList.Add(new Local(name, room, from, to, length));
                    // skriver ut när man bokat
                    Console.WriteLine($"Rum: {room} är bokat från: {from} till: {to}\n Längd på bokningen: {length}\nTryck enter för att gå tillbaka");
                    Console.ReadLine();
                    // avslutar loopen
                    break;
                }


            }
           
            
             


        }
        //Metod som skriver ut alla bokningar. *Moses gjort.  
        public void PrintBookings()
        {
            Console.Clear();
            Console.Write("NEDAN ÄR DINA BOKNINGAR");
            foreach (Local allBookings in BookingList)
            {
                Console.Write(allBookings);
            }
            Console.Write("\n\n\t\t\tTryck valfri knapp för att fortsätta...");
            Console.ReadKey();

        }     

        public void UpdateBooking()
        {
            throw new NotImplementedException();
        }

        public void RemoveBooking()
        {
            throw new NotImplementedException();
        }

        public void SortByYear()
        {
            throw new NotImplementedException();
        }
    }




    

}

