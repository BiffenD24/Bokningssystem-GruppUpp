using System.Text.Json;

namespace Bokningssystem_GruppUpp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //if sats som kollar om filen finns och om den gör det så deserialiserar den *Hannes gjort
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
                Console.Write("1 = Skapa ny sal eller grupprum.\n");
                Console.SetCursorPosition(40, 4);
                Console.Write("2 = Lista alla salar och grupprum med lämpliga egenskaper.\n");
                Console.SetCursorPosition(40, 5);
                Console.Write("3 = Skapa ny bokningar.\n");
                Console.SetCursorPosition(40, 6);
                Console.Write("4 = Ta bort en bokning.\n");
                Console.SetCursorPosition(40, 7);
                Console.Write("5 = Uppdatera en bokning.\n");
                Console.SetCursorPosition(40, 8);
                Console.Write("6 = Lista alla bokningar.\n");
                Console.SetCursorPosition(40, 9);
                Console.Write("7 = Lista bokningar från ett specifikt år.\n");
                Console.SetCursorPosition(40, 10);
                Console.Write("X = Avsluta.\n");
                menuChoice = Console.ReadLine();    

                if (menuChoice == "7")
                {
                    Console.Clear();
                    Local.SortByYear();  
                }
                else if (menuChoice == "2")
                {
                    Console.Clear();
                    Local.PrintRooms();
                }
                else if (menuChoice == "6")
                {
                    Console.Clear();
                    Hall.PrintBookings();
                }
                else if (menuChoice == "1")
                {
                    bool end = false;
                    //en loop som körs tills man skapar en sal eller grupprum
                    while (end == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Vill du skapa en Sal eller ett Grupprum");
                        string choice = Console.ReadLine() ?? "".ToLower();
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
                else if (menuChoice == "3")
                {
                    Hall hall = new Hall();
                    GroupRoom group = new GroupRoom();
                    Console.Clear();
                    Console.WriteLine("Vill du boka Sal eller grupprum");
                    switch (Console.ReadLine().ToLower() ?? "")
                    {
                        case "sal":
                            {
                                hall.NewBookable("");
                                break;
                            }
                        case "grupprum":
                            {
                                group.NewBookable("");
                                break;
                            }
                    }
                } 
                else if (menuChoice == "4")
                {
                    Console.Clear();
                    Local.RemoveBooking(); 
                }
                else if (menuChoice == "5") 
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


