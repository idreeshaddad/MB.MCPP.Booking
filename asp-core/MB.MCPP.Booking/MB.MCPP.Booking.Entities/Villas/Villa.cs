using MB.MCPP.BK.Entities.Addons;

namespace MB.MCPP.BK.Entities.Villas
{
    public class Villa
    {
        public Villa()
        {
            Addons = new List<Addon>();
            Images = new List<VillaImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int NumberOfOccupants { get; set; }
        public double Price { get; set; }
        public bool IsBooked { get; set; }

        public List<Addon> Addons { get; set; }

        public List<VillaImage> Images { get; set; }
    }
}
