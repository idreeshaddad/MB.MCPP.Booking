using System.ComponentModel.DataAnnotations.Schema;

namespace MB.MCPP.BK.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public double TotalPrice { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int NumberOfOccupants { get; set; }

        [NotMapped]
        public int NumberOfDays
        {
            get
            {
                return (BookingEnd - BookingStart).Days;
            }
        }
    }
}
