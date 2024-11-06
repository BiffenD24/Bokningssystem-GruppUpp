using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bokningssystem_GruppUpp
{
    internal class Hall :Local
    {
        //9.Metod som skapar nya salar *Hannes gjort
        public void NewHall() 
        {
            while (true)
            {
                //Ber användaren skriva in namnet för salen och sparar det i en string
                Console.WriteLine("Skriv Namnet av salen du vill skapa");
                string roomName = Console.ReadLine().ToLower();
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
                string roomTstr = Console.ReadLine();
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
                string roomCstr = Console.ReadLine();
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
                break;
                
            }
            
        }
    }
}
