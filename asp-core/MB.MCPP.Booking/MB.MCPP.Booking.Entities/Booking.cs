using System.ComponentModel.DataAnnotations.Schema;
using MB.MCPP.BK.Entities.Customers;
using MB.MCPP.BK.Entities.Villas;

namespace MB.MCPP.BK.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public double TotalPrice { get; set; }
        public int NumberOfOccupants { get; set; }

        [NotMapped]
        public int NumberOfDays
        {
            get
            {
                return (BookingEnd - BookingStart).Days;
            }
        }


        public int VillaId { get; set; }
        public Villa Villa { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
