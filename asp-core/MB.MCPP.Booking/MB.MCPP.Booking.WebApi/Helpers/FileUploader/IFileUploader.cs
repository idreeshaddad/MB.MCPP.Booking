using Microsoft.AspNetCore.Mvc;

namespace MB.MCPP.BK.WebApi.Helpers.FileUploader
{
    public interface IFileUploader
    {
        public string Upload(IFormFile file);
    }
}
