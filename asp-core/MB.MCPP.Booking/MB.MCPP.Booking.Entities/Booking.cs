using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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
