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

        // lista av bokningarna. OBS! Den måste vara statisk om sort by year metod ska funka. 
        public static List<Local> BookingList = new List<Local>(); 

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
        public Local(string roomscreated, double maxTime, int capacity)
        {
            Roomscreated = roomscreated;
            MaxTime = maxTime;
            Capacity = capacity;
        }

        // Metod för att göra ny bokning * Dennis gjort
        public static void NewBookable()
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
        public static void PrintBookings()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 5);
            Console.Write("NEDAN ÄR DINA BOKNINGAR");
            Console.SetCursorPosition(0, 7);
            foreach (Local allBookings in BookingList)
            {
                Console.Write(allBookings);
            }
            Console.Write("\n\n\t\t\tTryck valfri knapp för att fortsätta...");
            Console.ReadKey();
        }     

        public static void UpdateBooking()
        {
            throw new NotImplementedException();
        }

        // Metod för att ta bort bokningar. *Dennis gjort.
        public static void RemoveBooking()
        {
            bool removebooked = true;
            while (removebooked)
            {
                Console.Clear();

                // Ber användaren ange namn och sparar det i en sträng
                Console.WriteLine("Vilken bokning vill du ta bort?");
                Console.WriteLine("Ange namn som du bokat med");
                String? name = Console.ReadLine() ?? "";

                // ber användaren ange vilken sal den bokat och sparar det i en sträng
                Console.WriteLine("Ange vilken sal du bokat");
                String? room = Console.ReadLine() ?? "";

                // ber användaren ange från vilken tid man bokat och i vilket format det ska vara
                Console.WriteLine("Från vilken tid har du bokat? Ange År/Månad/Dag Timme/Minut");
                // sparar det i en bool så om parsningen lyckas skickas from tillbaka annars sätts fromtime bool till false
                var fromtime = DateTime.TryParse(Console.ReadLine(), out DateTime from);

                // om parsningen misslyckades körs denna kod
                if (fromtime == false)
                {
                    // skriver ut felmeddelande och ber användaren försöka igen
                    Console.WriteLine("Ange rätt format, Försök igen");
                    Console.WriteLine("Tryck valfri knapp för att försöka igen");
                    Console.ReadLine();
                    // continue för att gå tillbaka till början av loopen
                    continue;
                }

                // ber användaren ange till vilken tid den bokat
                Console.WriteLine("Till vilken tid har du bokat? Ange År/Månad/Dag Timme:Minut");
                // sparar i en bool. Om parsningen lyckas skickas variabeln to ut annars blir bool false
                var toTime = DateTime.TryParse(Console.ReadLine(), out DateTime to);
                // om parsningen misslyckades
                if (toTime == false)
                {
                    // skriver ut felmeddelande
                    Console.WriteLine("Amge rätt format, Försök igen");
                    Console.WriteLine("Tryck valfri knapp för att försöka igen");
                    Console.ReadLine();
                    continue;

                }

                // letar i listan efter det som användaren angivit
                var bookingToRemove = BookingList.FirstOrDefault(b => b.Room == room && b.Name == name && b.From == from && b.To == to);
                // om variabeln inte är lika med null alltså att den hittade bokningen, kommer denna kod att köras
                if (bookingToRemove != null)
                {
                    // bokningen tas bort från listan
                    BookingList.Remove(bookingToRemove);
                    // skriver ut till användaren
                    Console.WriteLine("Bokningen har tagits bort!");
                    Console.WriteLine("Tryck valfri knapp för att gå tillbaka");
                    Console.ReadLine();
                    Console.Clear();
                    // sätter loopen till false så att den avslutas
                    removebooked = false;

                }
                // om bokningen inte hittades
                else
                {
                    // skriver ut felmeddelande till användaren och går tillbaka till toppen av loopen
                    Console.WriteLine("Bokningen hittades inte, Vänligen försök igen");
                    Console.WriteLine("Tryck valfri knapp för att gå tillbaka");
                    Console.ReadLine();
                    continue;
                    
                }
            }
        }

        //Metoden som listar bokningar från ett specifikt år. *Moses gjort. 
        public static void SortByYear()
        {
            Console.Clear();
            bool searchYear = false;

            while (searchYear != true)
            { 
                Console.Write("Ange bokningsår. Obs! Endast år t.ex 2022: ");
                string? stringYearToSearch = Console.ReadLine();

                if (IfNotANumber(stringYearToSearch))
                {
                    Console.Clear();
                    byte yearTosearch = Convert.ToByte(stringYearToSearch);
                    Console.SetCursorPosition(50, 5);
                    Console.Write("Nedan är dina booknigar för år " + yearTosearch + ".");
                    Console.SetCursorPosition(0, 7);

                    foreach (Local yearBookings in BookingList)
                    {
                        int indexYear;
                        for (int indexYearToFind = 0; indexYearToFind < BookingList.Count; indexYearToFind++)
                        {
                            if (BookingList[indexYearToFind].From.Year == yearTosearch)
                            {
                                indexYear = indexYearToFind;
                                Console.WriteLine(BookingList[indexYearToFind]);
                            }
                        }
                    }
                    Console.WriteLine("\n\n\t\t\tTryck valfri knapp för att fortsätta...");
                    Console.ReadKey();
                    searchYear = true; 
                    break;
                }
                else
                {
                    Console.SetCursorPosition(50, 10);
                    Console.WriteLine("Endast siffror tack!");
                    Thread.Sleep(1200);
                    Console.Clear();
                } 
            }
            //Felhantering om ej tal eller tom sträng.  
            static bool IfNotANumber(string? userInput)
            {
                double numberHandler;
                return double.TryParse(userInput, out numberHandler);
            }
        }
    }




    

}

