using MB.MCPP.BK.Dtos.Rooms;

namespace MB.MCPP.BK.Dtos.Bookings
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public double TotalPrice { get; set; }
        public int RoomId { get; set; }
        public RoomDto Room { get; set; }
        public int NumberOfDays { get; set; }
    }
}
