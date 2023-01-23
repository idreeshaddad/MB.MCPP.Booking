using MB.MCPP.BK.Entities.Villas;

namespace MB.MCPP.BK.Entities.Addons
{
    public class Addon
    {
        public Addon()
        {
            Villas = new List<Villa>();
            Images = new List<AddonImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Villa> Villas { get; set; }

        public List<AddonImage> Images { get; set; }
    }
}
