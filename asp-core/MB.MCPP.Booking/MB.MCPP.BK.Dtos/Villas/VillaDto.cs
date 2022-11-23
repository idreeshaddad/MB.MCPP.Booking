using MB.MCPP.BK.Dtos.AddOns;

namespace MB.MCPP.BK.Dtos.Villas
{
    public class VillaDto
    {
        public VillaDto()
        {
            AddOnIds = new List<int>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int NumberOfOccupants { get; set; }
        public double Price { get; set; }
        public bool Vacant { get; set; }

        public List<int> AddOnIds { get; set; }
    }
}