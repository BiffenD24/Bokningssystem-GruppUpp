﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
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
        public virtual void NewBookable()
        {
            bool Null = false;
            // loop för att hålla igång programmet tills användaren har angivit rätt uppgifter
            while (Null == false)
            {
                Console.Clear();           
                // välkommnar användaren
                Console.WriteLine("Välkommen till bokningssystem");

                // ber användaren skriva in sitt namn och sparar det i en string variabel
                Console.WriteLine("Ange ditt namn");
                string name = Console.ReadLine()?? "".ToLower();
                Name = name;
                // kollar om strängen är tom eller null
                if (string.IsNullOrEmpty(name))
                {
                    // om den är null eller tom kommer det skrivas ut ett felmeddelande och användaren får börja om
                    Console.WriteLine("Felaktigt svar, försök igen\nTryck valfri knapp för att gå tillbaka");
                    Console.ReadLine();
                    Null = false;

                }
                else if (name is not null) 
                {
                    Null = true;
                    Name = name;
                }
            }
        }

        //Metod som skriver ut alla bokningar. *Moses gjort.  
        public static void PrintBookings()
        {
            Console.SetCursorPosition(50, 5);
            Console.Write("NEDAN ÄR DINA BOKNINGAR");
            Console.SetCursorPosition(0, 7);
            foreach (Local bookingsToPrint in BookingList)
            {
                Console.Write($"Namn:{bookingsToPrint.Name}\nRum:{bookingsToPrint.Room}\nFrån:{bookingsToPrint.From} Till:{bookingsToPrint.To}\nLängd:{bookingsToPrint.LengthOfBooking}\n");
            }
            Console.Write("\n\n\t\t\tTryck valfri knapp för att fortsätta...");
            Console.ReadKey();
        }

        //Metod för att uppdatera bokningar *Hannes gjort
        public static void UpdateBooking()
        {
            //ber användaren skriva in rummet och namnet på bokningen som ska uppdateras
            Console.WriteLine("Skriv namnet på rummet du vill uppdatera bokningen på");
            string RName = Console.ReadLine() ?? "".ToLower();

            Console.Clear();
            Console.WriteLine("Skriv namnet av personen på bokningen du vill uppdatera");
            string NName = Console.ReadLine() ?? "".ToLower();

            //kollar om rummet och namnet finns i listan
            for (int i = 0; i < BookingList.Count; i++)
            {
                //om rummet och namnet finns i listan kommer användaren få välja vad den vill uppdatera
                if (RName == BookingList[i].Room && NName == BookingList[i].Name)
                {
                    bool end = false;
                    //loop som körs tills användaren är klar
                    while (end == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Välj vilken del av bokningen du vill uppdatera");
                        Console.WriteLine("1.Byt person bokningen står på\n2.Byt rum på bokningen\n3.Byt tid på bokningen\n4.klar");

                        switch (int.Parse(Console.ReadLine() ?? ""))
                        {
                            //case 1 byter namnet på bokningen
                            case 1:
                                Console.Clear();
                                //ber användaren skriva in namnet som ska stå på bokningen
                                Console.WriteLine("Skriv personens namn som ska stå på bokningen");
                                string PName = Console.ReadLine() ?? "";

                                //byter namnet på bokningen
                                BookingList[i].Name = PName;
                                //skriver ut att namnet har bytts
                                Console.WriteLine($"Namnet har Byts till {PName}\nTryck ENTER för att fortsätta");
                                Console.ReadKey();
                                break;
                            //case 2 byter rummet på bokningen
                            case 2:
                                Console.Clear();
                                //ber användaren skriva in rummet som bokningen ska bytas till
                                Console.WriteLine("Skriv namnet på rummet du vill byta till");
                                string NewRoomName = Console.ReadLine() ?? "";

                                bool found = false;
                                //kollar om rummet finns i listan
                                for (int j = 0; j < Rooms.Count; j++)
                                {
                                    //om rummet finns i listan kommer rummet bytas
                                    if (NewRoomName == Rooms[j].Roomscreated)
                                    {
                                        //byter rummet
                                        BookingList[i].Room = NewRoomName;
                                        //skriver ut att rummet har bytts
                                        found = true;
                                        Console.WriteLine($"Rummet har bytits till{NewRoomName}\nTryck ENTER för att fortsätta");
                                        Console.ReadKey();
                                    }
                                }
                                //om rummet inte finns i listan kommer användaren få ett felmeddelande
                                if (found == false)
                                {
                                    Console.WriteLine($"Kunde inte hitta ett rum med namnet{NewRoomName}");
                                }
                                break;
                            //case 3 byter tiden på bokningen /delar av case 3 koden har kopierats från NewBookable metoden vilket Dennis har gjort
                            case 3:
                                Console.Clear();
                                bool save = false;
                                //frågar användaren vilken tid bokningen ska vara
                                Console.WriteLine("Från vilket datum vill du boka salen/grupprummet?\nAnge i detta format År/Månad/Dag Timme:Minut");

                                //sparar det i en bool variabel och försöker parsa inputen. Om parsningen lyckas kommer den skicka ut Datetime from.
                                var fromdate = DateTime.TryParse(Console.ReadLine(), out DateTime from);
                                if (fromdate == false)
                                {
                                    save = true;
                                    Console.WriteLine("Felaktigt format, försök igen\nTryck enter för att gå tillbaka");
                                    Console.ReadLine();
                                    break;
                                }

                                //frågar användaren hur länge bokningen ska vara
                                Console.WriteLine("Hur länge önskar du boka?\nAnge i detta format År/Månad/Dag Timme:Minut");
                                //sparar det i en bool variabel och försöker parsa inputen. Om parsningen lyckas kommer den skicka ut Datetime from.
                                var todate = DateTime.TryParse(Console.ReadLine(), out DateTime to);

                                if (todate == false)
                                {
                                    save = true;
                                    Console.WriteLine("Felaktigt format, försök igen\nTryck valfri knapp för att gå tillbaka");
                                    Console.ReadLine();
                                    break;
                                }

                                //beräknar längden på bokningen och sparar det.
                                TimeSpan length = to - from;

                                //kollar om rummet är ledigt
                                if (BookingList.Any(b => b.Room == BookingList[i].Room && (from < b.To && to > b.From)))
                                {
                                    Console.WriteLine("Rummet är inte tillgänglig den tiden \nTryck ENTER för att fortsätta");
                                    Console.ReadKey();
                                    save = true;
                                    break;
                                }

                                //om rummet är ledigt eller inget annat del uptäkts kommer tiden att bytas
                                if (save == false)
                                {
                                    //byter tiden på bokningen
                                    BookingList[i].From = from;
                                    BookingList[i].To = to;
                                    BookingList[i].LengthOfBooking = length;
                                    //skriver ut att tiden har bytts
                                    Console.WriteLine($"Tiden har ändrats till\n Från{from} till: {to}\n Längd på bokningen: {length}\nTryck enter för att gå tillbaka");
                                    Console.ReadKey();
                                }
                                break;
                            //case 4 avslutar loopen
                            case 4:
                                end = true;
                                break;

                        }
                    }
                }
            }
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
                String? name = Console.ReadLine() ?? "".ToLower();

                // ber användaren ange vilken sal den bokat och sparar det i en sträng
                Console.WriteLine("Ange vilken sal/grupprum du bokat");
                String? room = Console.ReadLine() ?? "".ToLower();

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
            bool yearFound = false; //Om året hittas eller inte. 

            while (searchYear != true)
            { 
                Console.Write("Ange bokningsår. Obs! Endast år t.ex 2022: ");
                string? stringYearToSearch = Console.ReadLine() ?? "";
                bool isEmpty = !BookingList.Any(); //Kolla om bokningslistan är tom.
             
                if (IfNotANumber(stringYearToSearch))
                {
                    Console.Clear();
                    int yearTosearch = Convert.ToInt32(stringYearToSearch);

                    if (isEmpty)
                    {
                        Console.SetCursorPosition(50, 5);
                        Console.Write("Bokningslistan är tom. Skapa bokningar först!");
                        Console.SetCursorPosition(0, 7);
                        Console.Write("\n\n\t\t\t\t\t\t\tTryck valfri knapp för att fortsätta...");
                        Console.ReadKey();
                        break;
                    }
                    else 
                    {
                        Console.SetCursorPosition(50, 5);
                        Console.Write("Nedan är dina boknigar för år " + yearTosearch + ".");
                        Console.SetCursorPosition(0, 7);

                        foreach (Local yearBookings in BookingList)
                        {
                            int indexYear;
                            for (int indexYearToFind = 0; indexYearToFind < BookingList.Count; indexYearToFind++)
                            {
                                if (BookingList[indexYearToFind].From.Year == yearTosearch)
                                {
                                    indexYear = indexYearToFind;
                                    Console.WriteLine("Rum: " + BookingList[indexYearToFind].Room + " är bokat från: " + BookingList[indexYearToFind].From + " till: " + BookingList[indexYearToFind].To + ".");
                                    yearFound = true;
                                    continue; //Fortsätter till nästa if sats.  
                                }
                                else if (BookingList[indexYearToFind].To.Year == yearTosearch)
                                {
                                    indexYear = indexYearToFind;
                                    Console.WriteLine("Rum: " + BookingList[indexYearToFind].Room + " är bokat från: " + BookingList[indexYearToFind].From + " till: " + BookingList[indexYearToFind].To + ".");
                                    yearFound = true;
                                }
                                else if (yearFound == false)
                                {
                                    Console.WriteLine("Vi har inga bokningar för år " + yearTosearch);
                                    break;
                                }
                            }
                            break;

                        }
                        Console.WriteLine("\n\n\t\t\tTryck valfri knapp för att fortsätta...");
                        Console.ReadKey();
                        searchYear = true;
                        break;
                    }
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

        //Metod som tar all text i json filen och deserialiserar den till en lista. *Hannes gjort.
        public static void Deserialize()
        {
            Rooms = JsonSerializer.Deserialize<List<Local>>(File.ReadAllText("Rooms.json"));
        }

        //Metod för att skriva ut alla rum och deras egenskaper. *Hannes gjort
        public static void PrintRooms()
        {
            //if sats som kollar om rum har blivit skapade och ger ett medelande om inga existerar.
            if (Rooms.Count == 0)
            {
                Console.WriteLine("Det finns inga skapade Salar eller Grupprum");
            }
            //skriver ut alla rum och deras egenskaper
            foreach (Local s in Rooms)
            {
                Console.WriteLine($"Rum:{s.Roomscreated}\nMaxtid för bokning:{s.MaxTime}\nKapacitet:{s.Capacity}\n");
            }
            Console.WriteLine("Tryck ENTER för att fortsätta");
            Console.ReadKey();
        }
    }   

}

