using MB.MCPP.BK.WebApi.Helpers.ImageUploader;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace MB.MCPP.BK.WebApi.Helpers.FileUploader;

public class ImageUploader : IImageUploader
{
    #region Constructor and Data Memebers

    public readonly string _pathToSave;

    public ImageUploader(IOptions<ImageUploaderConfig> _imageUploaderConfig)
    {
        _pathToSave = $"{Directory.GetCurrentDirectory()}{_imageUploaderConfig.Value.FolderName}";
    }

    #endregion

    public List<string> Upload(IFormFile[] files)
    {
        var filesNames = new List<string>();

        foreach (var file in files)
        {
            string fileName = GetFileName(file);
            filesNames.Add(fileName);

            var fullPath = Path.Combine(_pathToSave, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

        }

        return filesNames;
    }

    #region Private Methods

    private string GetFileName(IFormFile file)
    {
        var myFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var fileExt = Path.GetExtension(myFileName);

        return $"{Guid.NewGuid()}{fileExt}";
    }

    #endregion
}
