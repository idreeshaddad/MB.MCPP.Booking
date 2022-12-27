using MB.MCPP.BK.WebApi.Helpers.ImageUploader;
using System.Net.Http.Headers;

namespace MB.MCPP.BK.WebApi.Helpers.FileUploader;

public class ImageUploader : IImageUploader
{
    public string Upload(IFormFile file)
    {
        var folderName = Path.Combine("Resources", "Images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName); // C:\wow\Resources\Images

        var myFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'); // wow.png
        var fileExt = Path.GetExtension(myFileName); // .png

        var fileNameGUIDWithExt = $"{Guid.NewGuid()}{fileExt}"; // 34234-sdfwe423-sfd234234.png
        var fullPath = Path.Combine(pathToSave, fileNameGUIDWithExt); // C:\wow\Resources\Images\34234-sdfwe423-sfd234234.png

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileNameGUIDWithExt;
    }
}
