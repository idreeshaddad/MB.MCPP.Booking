namespace MB.MCPP.BK.WebApi.Helpers.ImageUploader
{
    public interface IImageUploader
    {
        public string Upload(IFormFile file);
    }
}
