using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_GruppUpp
{
    internal class Hall :Local
    {
        public List<Hall> hallList = new List<Hall>(); //Lista för alla Salar
        
        public string Name { get; set; } //Temporära egenskaper som används tills egenskaper i lokal har skapats
        public double MaxTime { get; set; }
        public int Capacity { get; set; }

        public Hall(string name, double maxTime, int capacity) //Konstruktor för hur egenskaperna av Salarna ska in i listan
        {
            Name = name;
            MaxTime = maxTime;
            Capacity = capacity;
        }
        public void NewHall() //9.Metod som skapar nya salar *Hannes gjort
        {
            Console.WriteLine("Skriv Namnet av salen du vill skapa");
            string hallName = Console.ReadLine().ToLower();
            bool found = false;
            for (int i = 0; i < hallList.Count; i++)    //7.kollar igenom listan och ser till att en sall med namnet redan existerar *Hannes gjort
            {
                if (hallList[i].Name == hallName)
                {
                    Console.WriteLine($"ERROR!\nDet finns redan en sal med namnet {hallName}");
                    found = true;
                    Console.WriteLine("Tryck ENTER för att fortsätta");
                    Console.ReadKey();
                    break;
                }
            }
            if(found == false) //If sats som skippas över. Om användaren försökt skapa en ny sal med samma namn som en som redan finns i listan
            {
                Console.WriteLine("Skriv in den maximala tiden du får boka den hära salen");
                double hallTime = double.Parse(Console.ReadLine());

                Console.WriteLine("Skriv in den mängd personer som får plats i salen");
                int hallCapacity = int.Parse(Console.ReadLine());

                hallList.Add(new(hallName, hallTime, hallCapacity));
            }
        }
        public void ListAllHalls() 
        {
            if (hallList.Count == 0)
            {
                Console.WriteLine("Inga  salar har skapats än.");
                return;
            }
            Console.Clear();
            Console.WriteLine("Lista över alla salar:");
            foreach (var hall in hallList)
            {
                Console.WriteLine($"Namn: {hall.Name}, Max bokningstid: {hall.MaxTime} timmar, Kapacitet: {hall.Capacity} personer");
            }
            Console.WriteLine("\nTryck valfri knapp för att fortsätta...");
            Console.ReadKey();
        }
    }
}
