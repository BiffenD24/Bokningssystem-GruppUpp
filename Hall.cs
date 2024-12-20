﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bokningssystem_GruppUpp
{
    internal class Hall :Local
    {
        //9.Metod som skapar nya salar *Hannes gjort
        public static void NewHall() 
        {
            while (true)
            {
                //Ber användaren skriva in namnet för salen och sparar det i en string
                Console.WriteLine("Skriv Namnet av salen du vill skapa");
                string? roomName = Console.ReadLine() ?? "".ToLower();
                // Kollar om stringen är tom eller null och ger felmedelande och användaren får börja om, om sant
                if (string.IsNullOrEmpty(roomName))
                {
                    Console.WriteLine("ERROR!\nDu måste skriv ett giltigt svar\nTryck ENTER för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
                //7.kollar igenom listan och ser om en sall med namnet redan existerar *Hannes gjort
                bool found = false;
                for (int i = 0; i < Rooms.Count; i++)    
                {
                    if (Rooms[i].Roomscreated == roomName)
                    {
                        // om rummet redan existerar kommer det skrivas ut ett felmeddelande och användaren får börja om
                        Console.WriteLine($"ERROR!\nDet finns redan en sal med namnet {roomName}");
                        Console.WriteLine("Tryck ENTER för att fortsätta");
                        Console.ReadKey();
                        found = true;
                    }
                }
                if (found == true)
                {
                    continue;
                }
                Console.WriteLine("Skriv in den maximala tiden du får boka den hära salen");
                string roomTstr = Console.ReadLine() ?? "";
                // Kollar om stringen är tom eller null och ger felmedelande och användaren får börja om, om sant
                if (string.IsNullOrEmpty(roomTstr))
                {
                    Console.WriteLine("ERROR!\nDu måste skriv ett giltigt svar\nTryck ENTER för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
                //Konverterar stringen till double
                double roomTime = double.Parse(roomTstr);
                
                Console.WriteLine("Skriv in den mängd personer som får plats i salen");
                string? roomCstr = Console.ReadLine() ?? "";
                // Kollar om stringen är tom eller null och ger felmedelande och användaren får börja om, om sant
                if (string.IsNullOrEmpty(roomTstr))
                {
                    Console.WriteLine("ERROR!\nDu måste skriv ett giltigt svar\nTryck ENTER för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
                //konverterar stringen till int
                int roomCapacity = int.Parse(roomCstr);
                
                //Lägger till all info i Rooms listan
                Rooms.Add(new(roomName, roomTime, roomCapacity));
                //Sparar listan i en json fil
                string? text = JsonSerializer.Serialize(Rooms);
                File.WriteAllText("Rooms.json", text);
                break;
                
            }
            
        }

        public override void NewBookable()
        {
            base.NewBookable();
            while (true)
            {
                Console.Clear();
                
                // ber användaren ange sal eller grupprum och sparar det i en sträng
                Console.WriteLine("Vilken sal vill du boka?");
                string? room = Console.ReadLine() ?? "".ToLower();
                Room = room;
                // Kollar att rummet finns i listan 
                var roomFound = Rooms.FirstOrDefault(a => a.Roomscreated == room);

                // om variabeln är null kommer användaren få ett felmeddelande och börja om
                if (roomFound == null)
                {
                    Console.WriteLine("Salen existerar inte, försök igen\nTryck valfri knapp för att gå tillbaka");
                    Console.ReadLine();
                    // går tillbaka till början av loopen
                    continue;
                }

                // ber användaren om start-tid för bokningen och ber den använda rätt format
                Console.WriteLine("Från vilket datum vill du boka salen?\nAnge i detta format År/Månad/Dag Timme:Minut");
                // sparar det i en bool variabel och försöker parsa inputen. Om parsningen lyckas kommer den skicka ut Datetime from.
                var fromdate = DateTime.TryParse(Console.ReadLine(), out DateTime from);
                From = from;
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
                To = to;
                // om parsningen inte går igenom kommer bool bli false och användaren får ett felmeddelande och får börja om
                if (todate == false)
                {
                    Console.WriteLine("Felaktigt format, försök igen\nTryck valfri knapp för att gå tillbaka");
                    Console.ReadLine();
                    continue;  
                }
                // beräknar längden på bokningen och sparar det.
                TimeSpan length = to - from;
                LengthOfBooking = length;
                // if-sats för att kolla om det redan finns en bokning på samma rum och tid. Om det finns det kommer användaren få ett felmeddelande och börja om bokningen
                if (BookingList.Any(b => b.Room == room && (from < b.To && to > b.From)))
                {
                    Console.WriteLine("Salen är inte tillgänglig den tiden \nTryck valfri knapp för att börja om");
                    Console.ReadLine();
                    continue;
                }
                // annars om det inte finns en bokad tid kommer denna kod köras
                else
                {
                    // Lägger till i listan för bokningar
                    BookingList.Add(this);
                    // skriver ut när man bokat
                    Console.WriteLine($"Sal: {room} är bokat från: {from} till: {to}\n Längd på bokningen: {length}\nTryck enter för att gå tillbaka");
                    Console.ReadLine();
                    // avslutar loopen
                    break;
                }
            }



        }
    }
}
