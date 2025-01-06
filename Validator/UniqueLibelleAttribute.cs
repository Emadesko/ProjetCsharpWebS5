using System.ComponentModel.DataAnnotations;
using ProjetCsharpWebS5.Services;

namespace ProjetCsharpWebS5.Validator
{
    public class UniqueLibelleAttribute : ValidationAttribute {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var service = (IProduitService)validationContext.GetService(typeof(IProduitService));
            var libelle = (string)value;

            if (service.GetDatasAsync().Result.Any(c => c.Libelle.ToLower() == libelle.ToLower()))
            {
                return new ValidationResult("Ce libelle est déjà utilisé.");
            }
        
            return ValidationResult.Success;
        }
    }
}