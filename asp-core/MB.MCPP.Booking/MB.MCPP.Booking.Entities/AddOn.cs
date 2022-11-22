namespace MB.MCPP.BK.Entities
{
    public class AddOn
    {
        public AddOn()
        {
            Villas = new List<Villa>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Villa> Villas { get; set; }
    }
}
