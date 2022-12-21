using MB.MCPP.BK.WebApi.Helpers.FileUploader;
using Microsoft.AspNetCore.Mvc;

namespace MB.MCPP.BK.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IFileUploader _fileUploader;

        public UploadController(IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload(IFormFile file)
        {
            if (file.Length > 0)
            {
                var imageName = _fileUploader.Upload(file);
                return Ok(new { imageName });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
