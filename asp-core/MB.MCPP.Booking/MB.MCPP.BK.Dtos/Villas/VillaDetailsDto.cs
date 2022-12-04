using MB.MCPP.BK.Dtos.Addons;

namespace MB.MCPP.BK.Dtos.Villas
{
    public class VillaDetailsDto
    {
        public VillaDetailsDto()
        {
            Addons = new List<AddonDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int NumberOfOccupants { get; set; }
        public double Price { get; set; }
        public bool IsBooked { get; set; }

        public List<AddonDto> Addons { get; set; }
    }
}