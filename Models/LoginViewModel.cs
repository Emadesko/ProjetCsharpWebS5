using System.ComponentModel.DataAnnotations;

namespace ProjetCsharpWebS5.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Le login est obligatoire")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}