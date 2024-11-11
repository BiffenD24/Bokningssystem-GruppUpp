using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_GruppUpp
{
    internal class BookingManager
    {
        private List<Booking> bookings;

        public BookingManager()
        {
            bookings = new List<Booking>();
            // Load bookings from file or initialize a new list
        }

        public void UpdateBooking(int bookingId)
        {
            var booking = bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            Console.WriteLine("Current booking details:");
            Console.WriteLine(booking);

            Console.WriteLine("Enter new room name (or press Enter to keep current):");
            string newRoomName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newRoomName))
            {
                booking.RoomName = newRoomName;
            }

            Console.WriteLine("Enter new start time (yyyy-MM-dd HH:mm) (or press Enter to keep current):");
            string newStartTime = Console.ReadLine();
            if (DateTime.TryParse(newStartTime, out DateTime startTime))
            {
                booking.StartTime = startTime;
            }

            Console.WriteLine("Enter new end time (yyyy-MM-dd HH:mm) (or press Enter to keep current):");
            string newEndTime = Console.ReadLine();
            if (DateTime.TryParse(newEndTime, out DateTime endTime))
            {
                booking.EndTime = endTime;
            }

            Console.WriteLine("Enter new booker name (or press Enter to keep current):");
            string newBookerName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newBookerName))
            {
                booking.BookerName = newBookerName;
            }

            Console.WriteLine("Booking updated successfully.");
            SaveBookingsToFile();
        }

        private void SaveBookingsToFile()
        {
            // Implement file saving logic here
            Console.WriteLine("Bookings have been saved to file.");
        }
        private void LoadBookingsFromFile()
        {
            // Read from a file and populate the bookings list
        }

    }

}
