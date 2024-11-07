namespace Bokningssystem_GruppUpp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                Console.Write("E = Lista alla salar med lämpliga egenskaper.\n");
                Console.SetCursorPosition(40, 5);
                Console.Write("L = Lista alla bokningar.\n");
                Console.SetCursorPosition(40, 6);
                Console.Write("N = Skapa nya salar.\n");
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
                    //OBS Lägg in punkt 8 här. 
                }
                else if (menuChoice == "L" || menuChoice == "l")
                {
                    Console.Clear();
                    Local.PrintBookings();   
                }
                else if (menuChoice == "N" || menuChoice == "n")
                {
                    Console.Clear();
                    Hall.NewHall(); 
                    //OBS Lägg in punkt 9 här. 
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


