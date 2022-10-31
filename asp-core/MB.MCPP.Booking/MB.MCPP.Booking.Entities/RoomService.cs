using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.MCPP.BK.Entities
{
    public class RoomService
    {
        public RoomService()
        {
            Rooms = new List<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
