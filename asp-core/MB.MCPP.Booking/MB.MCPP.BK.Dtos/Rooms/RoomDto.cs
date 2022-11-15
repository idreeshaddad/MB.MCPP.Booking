using MB.MCPP.BK.Dtos.RoomServices;

namespace MB.MCPP.BK.Dtos.Rooms
{
    public class RoomDto
    {
        public RoomDto()
        {
            Services = new List<RoomServiceDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int NumberOfOccupants { get; set; }
        public double Price { get; set; }
        public bool Occupied { get; set; }

        public List<RoomServiceDto> Services { get; set; }
    }
}