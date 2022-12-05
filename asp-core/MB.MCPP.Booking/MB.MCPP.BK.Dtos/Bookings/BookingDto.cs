
namespace MB.MCPP.BK.Dtos.Bookings
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public int NumberOfOccupants { get; set; }

        public int VillaId { get; set; }
        public int CustomerId { get; set; }
    }
}
