﻿namespace MB.MCPP.BK.Dtos.Bookings
{
    public class BookingListDto
    {
        public int Id { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public double TotalPrice { get; set; }
        public int NumberOfOccupants { get; set; }
        public int NumberOfDays { get; set; }

        public string VillaName { get;  set; }
        public string CustomerFullName { get; set; }
    }
}
