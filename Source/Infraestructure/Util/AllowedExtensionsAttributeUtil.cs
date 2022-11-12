﻿using System.ComponentModel.DataAnnotations;

namespace cadastro_documento_api.Source.Infraestructure.Util
{
    public class AllowedExtensionsAttributeUtil : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttributeUtil(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Esta extensão de arquivo não é permitida";
        }
    }
}
