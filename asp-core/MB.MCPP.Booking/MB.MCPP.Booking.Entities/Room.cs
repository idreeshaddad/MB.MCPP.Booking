using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.MCPP.BK.Entities
{
    public class Room
    {
        public Room()
        {
            Services = new List<RoomService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int NumberOfOccupants { get; set; }
        public double Price { get; set; }
        public bool Occupied { get; set; }

        public List<RoomService> Services { get; set; }
    }
}
