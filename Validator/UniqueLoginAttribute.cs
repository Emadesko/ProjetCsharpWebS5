using System.ComponentModel.DataAnnotations;
using ProjetCsharpWebS5.Services;

namespace ProjetCsharpWebS5.Validator
{
    public class UniqueLoginAttribute : ValidationAttribute {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IUserService)validationContext.GetService(typeof(IUserService));
            var login = (string)value;

            if (service.GetDatasAsync().Result.Any(c => c.Login.ToLower() == login.ToLower()))
            {
                return new ValidationResult("Ce login est déjà utilisé.");
            }
        
            return ValidationResult.Success;
        }
    }
}