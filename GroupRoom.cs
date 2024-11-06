using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_GruppUpp
{
    internal class GroupRoom :Local
    {
        //9.skapar ett nytt Grupprum *Hannes gjort
        public void NewGroupRoom()
        {
            while (true)
            {
                //Ber användaren skriva in namnet för Grupprummet och sparar det i en string
                Console.WriteLine("Skriv Namnet av Grupprummet du vill skapa");
                string roomName = Console.ReadLine().ToLower();
                // Kollar om stringen är tom eller null och ger felmedelande och användaren får börja om, om sant
                if (string.IsNullOrEmpty(roomName))
                {
                    Console.WriteLine("ERROR!\nDu måste skriv ett giltigt svar\nTryck ENTER för att fortsätta");
                    Console.ReadKey();
                    continue;
                }
                //7.kollar igenom listan och ser om ett grupprum med namnet redan existerar *Hannes gjort
                for (int i = 0; i < Rooms.Count; i++)    
                {
                    if (Rooms[i].Roomscreated == roomName)
                    {
                        Console.WriteLine($"ERROR!\nDet finns redan ett Grupprum med namnet {roomName}");
                        Console.WriteLine("Tryck ENTER för att fortsätta");
                        Console.ReadKey();
                        continue;
                    }
                }

                Console.WriteLine("Skriv in den maximala tiden du får boka det hära Grupprummet");
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

                Console.WriteLine("Skriv in den mängd personer som får plats i Grupprummet");
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
