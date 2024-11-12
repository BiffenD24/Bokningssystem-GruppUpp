using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_GruppUpp
{
    //Mohamed har gjort/går inte att använda
    internal class Booking
    {
        public int BookingId { get; set; }
        public string RoomName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string BookerName { get; set; }

        // Method to display booking details
        public override string ToString()
        {
            return $"BookingId: {BookingId}, Room: {RoomName}, Time: {StartTime:yyyy-MM-dd HH:mm} - {EndTime:HH:mm}, Booker: {BookerName}";
        }
    }
}
