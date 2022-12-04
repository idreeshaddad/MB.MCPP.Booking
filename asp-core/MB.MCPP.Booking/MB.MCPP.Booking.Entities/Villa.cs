namespace MB.MCPP.BK.Entities
{
    public class Villa
    {
        public Villa()
        {
            Addons = new List<Addon>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int NumberOfOccupants { get; set; }
        public double Price { get; set; }
        public bool IsBooked { get; set; }

        public List<Addon> Addons { get; set; }
    }
}
