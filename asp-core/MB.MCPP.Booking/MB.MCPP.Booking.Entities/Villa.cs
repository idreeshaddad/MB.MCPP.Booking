﻿namespace MB.MCPP.BK.Entities
{
    public class Villa
    {
        public Villa()
        {
            AddOns = new List<AddOn>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int NumberOfOccupants { get; set; }
        public double Price { get; set; }
        public bool Vacant { get; set; }

        public List<AddOn> AddOns { get; set; }
    }
}