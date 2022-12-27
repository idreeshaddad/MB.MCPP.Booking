using MB.MCPP.BK.WebApi.Attributes;
using MB.MCPP.BK.WebApi.Helpers.ImageUploader;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public IActionResult Upload([AllowedExtensions()]IFormFile file)
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
