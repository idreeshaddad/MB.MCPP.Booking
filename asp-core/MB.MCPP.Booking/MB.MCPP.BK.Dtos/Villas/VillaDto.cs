using MB.MCPP.BK.Dtos.Uploaders;

namespace MB.MCPP.BK.Dtos.Villas
{
    public class VillaDto
    {
        public VillaDto()
        {
            AddonIds = new List<int>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int NumberOfOccupants { get; set; }
        public double Price { get; set; }
        public bool IsBooked { get; set; }

        public List<int> AddonIds { get; set; }
        public List<UploaderImageDto> VillaImages { get; set; }
    }
}