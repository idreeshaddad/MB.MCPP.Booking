using MB.MCPP.BK.WebApi.Attributes;
using MB.MCPP.BK.WebApi.Helpers.ImageUploader;
using Microsoft.AspNetCore.Mvc;

namespace MB.MCPP.BK.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IImageUploader _fileUploader;

        public UploadController(IImageUploader fileUploader)
        {
            _fileUploader = fileUploader;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload([AllowedExtensions()]IFormFile[] files)
        {
            if (files.Length > 0)
            {
                var imagesNames = _fileUploader.Upload(files);
                return Ok(new { imagesNames });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
