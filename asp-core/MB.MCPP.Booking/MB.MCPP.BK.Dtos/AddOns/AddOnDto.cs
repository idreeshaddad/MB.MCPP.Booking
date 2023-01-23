using MB.MCPP.BK.Dtos.Uploaders;

namespace MB.MCPP.BK.Dtos.Addons
{
    public class AddonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public List<UploaderImageDto> Images { get; set; }
    }
}
