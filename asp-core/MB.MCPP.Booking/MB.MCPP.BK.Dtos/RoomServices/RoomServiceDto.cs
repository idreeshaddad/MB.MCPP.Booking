using MB.MCPP.BK.Dtos.Rooms;

namespace MB.MCPP.BK.Dtos.RoomServices
{
    public class RoomServiceDto
    {
        public RoomServiceDto()
        {
            Rooms = new List<RoomDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
