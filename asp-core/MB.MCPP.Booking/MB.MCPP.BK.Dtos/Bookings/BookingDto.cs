using MB.MCPP.BK.Dtos.Villas;

namespace MB.MCPP.BK.Dtos.Bookings
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public double TotalPrice { get; set; }
        public int VillaId { get; set; }
        public VillaDto Villa { get; set; }
        public int NumberOfDays { get; set; }
    }
}
