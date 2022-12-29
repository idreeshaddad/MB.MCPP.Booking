namespace MB.MCPP.BK.WebApi.Helpers.ImageUploader
{
    public interface IImageUploader
    {
        public List<string> Upload(IFormFile[] files);
    }
}
