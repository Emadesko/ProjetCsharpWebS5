using System.ComponentModel.DataAnnotations;
using ProjetCsharpWebS5.Services;

namespace ProjetCsharpWebS5.Validator
{
    public class UniqueTelephoneAttribute : ValidationAttribute {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IClientService)validationContext.GetService(typeof(IClientService));
            var telephone = (string)value;

            if (service.GetDatasAsync().Result.Any(c => c.Telephone == telephone))
            {
                return new ValidationResult("Ce téléphone est déjà utilisé.");
            }
        
            return ValidationResult.Success;
        }
    }
}