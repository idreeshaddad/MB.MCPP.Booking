using System.ComponentModel.DataAnnotations;

namespace MB.MCPP.BK.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute()
        {
            _extensions = new string[] { ".png", ".jpg", ".jpeg", ".gif" };
        }

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isValid = true;

            var files = value as IFormFile[];

            if (files.Any()) // Same as typing files.Length > 0 
            {
                foreach (var file in files)
                {
                    var extension = Path.GetExtension(file.FileName);

                    if (!_extensions.Contains(extension.ToLower()))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }

        public string GetErrorMessage()
        {
            var errorMsg = $"File type not valid. Allowed file types are: {String.Join("|", _extensions)}";
            return errorMsg;
        }
    }
}
