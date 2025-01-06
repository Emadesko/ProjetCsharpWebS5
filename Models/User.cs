using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ProjetCsharpWebS5.Validator;

namespace ProjetCsharpWebS5.Models
{
    public class User {
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Le login doit avoir au moins 3 caractères et inférieur à 20 caractères")]
        [Required(ErrorMessage = "Le login est obligatoire")]
        [UniqueLogin]
        public string Login { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 4, ErrorMessage = "Le mot de passe doit avoir au moins 4 caractères")]
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        public string Password
        {
            get => _passwordHash;
            set
            {
                if (!string.IsNullOrEmpty(value) && !value.Contains("$2a$"))
                {
                    _passwordHash = BCrypt.Net.BCrypt.HashPassword(value); // Hacher le mot de passe
                }else{
                    _passwordHash = value; // Utiliser le mot de passe non-haché si déjà existant
                }
            }
        }
        private string _passwordHash;

        [Required(ErrorMessage = "Le role est obligatoire")]
        public string Role { get; set; }
        [JsonIgnore]
        public virtual Client? Client { get; set; }

        
        public bool VerifyPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, Password);
        }

    }
}