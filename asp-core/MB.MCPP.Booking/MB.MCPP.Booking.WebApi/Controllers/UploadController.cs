using MB.MCPP.BK.Dtos.Uploaders;
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

                var villaImages = GetVillaImages(imagesNames);

                return Ok(villaImages);
            }
            else
            {
                return BadRequest();
            }
        }

        private List<UploaderImageDto> GetVillaImages(List<string> imagesNames)
        {
            var imagesNamesDtos = new List<UploaderImageDto>();

            foreach (var imageName in imagesNames)
            {
                var villaImage = new UploaderImageDto();
                villaImage.Id = 0;
                villaImage.Name = imageName;

                imagesNamesDtos.Add(villaImage);
            }

            return imagesNamesDtos;
        }
    }
}
