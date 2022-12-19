using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace MB.MCPP.BK.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                
                // ON MOL PC  =>  C:\users\gelno\repos\fileUpload\Resouces\Images
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName); 

                if (file.Length > 0)
                {
                    var myFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileExt = Path.GetExtension(myFileName);

                    var fileNameGUID = $"{Guid.NewGuid()}{fileExt}";
                    var fullPath = Path.Combine(pathToSave, fileNameGUID);
                    var dbPath = Path.Combine(folderName, fileNameGUID);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
