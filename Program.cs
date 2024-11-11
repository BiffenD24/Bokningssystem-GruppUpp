using System.Text.Json;

namespace Bokningssystem_GruppUpp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //if sats som kollar om filen finns och om den gör det så deserialiserar den
            if (File.Exists("Rooms.json"))
            {
                Local.Deserialize();
            }
            Console.Clear(); 
            string? menuChoice = ""; 
            bool quitBooking = false;

            //Menval *Moses gjort
            while (quitBooking != true)
            {
                Console.Clear();
                Console.SetCursorPosition(50, 1);
                Console.Write("VÄLJ ETT AV FÖLJANDE");
                Console.SetCursorPosition(40, 3);
                Console.Write("B = Lista bokningar från ett specifikt år.\n");
                Console.SetCursorPosition(40, 4);
                Console.Write("E = Lista alla salar och grupprum med lämpliga egenskaper.\n");
                Console.SetCursorPosition(40, 5);
                Console.Write("L = Lista alla bokningar.\n");
                Console.SetCursorPosition(40, 6);
                Console.Write("N = Skapa ny sal eller grupprum.\n");
                Console.SetCursorPosition(40, 7);
                Console.Write("S = Skapa ny bokningar.\n");
                Console.SetCursorPosition(40, 8);
                Console.Write("T = Ta bort en bokning.\n");
                Console.SetCursorPosition(40, 9);
                Console.Write("U = Uppdatera en bokning.\n");
                Console.SetCursorPosition(40, 10);
                Console.Write("X = Avsluta.\n");
                menuChoice = Console.ReadLine();    

                if (menuChoice == "B" || menuChoice == "b")
                {
                    Console.Clear();
                    Local.SortByYear();  
                }
                else if (menuChoice == "E" || menuChoice == "e")
                {
                    Console.Clear();
                    Local.PrintRooms();
                }
                else if (menuChoice == "L" || menuChoice == "l")
                {
                    Console.Clear();
                    Local.PrintBookings();   
                }
                else if (menuChoice == "N" || menuChoice == "n")
                {
                    bool end = false;
                    //en loop som körs tills man skapar en sal eller grupprum
                    while (end == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Vill du skapa en Sal eller ett Grupprum");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "sal")
                        {
                            Console.Clear();
                            Hall.NewHall();
                            end = true;
                        }
                        else if (choice == "grupprum")
                        {
                            Console.Clear();
                            GroupRoom.NewGroupRoom();
                            end = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("ERROR! Felaktit svar \nTryck ENTER för att försöka igen");
                            Console.ReadKey();
                        }
                    }
                }
                else if (menuChoice == "S" || menuChoice == "s")
                {
                    Console.Clear();
                    Local.NewBookable();
                } 
                else if (menuChoice == "T" || menuChoice == "t")
                {
                    Console.Clear();
                    Local.RemoveBooking(); 
                }
                else if (menuChoice == "U" || menuChoice == "u")
                {
                    Console.Clear();
                    Local.UpdateBooking(); 
                }
                else if (menuChoice == "X" || menuChoice == "x")
                {
                    quitBooking = true;
                }
            }

            //Programmet avslutas här.  
            Console.Clear();
            Console.SetCursorPosition(50, 15);
            Console.Write("Tack för besöket!\n\n\n\n\n\n");
            Thread.Sleep(5000);
        }
    }
}


