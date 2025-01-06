using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ProjetCsharpWebS5.Validator;

namespace ProjetCsharpWebS5.Models
{
    public class Client{

        public int Id { get; set; }
        [Required(ErrorMessage ="Le nom est obligatoire")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Le nom doit avoir au moins 5 caractères et inférieur à 20 caractères")]
        public string Nom { get; set; }
        [Required(ErrorMessage ="Le prenom est obligatoire")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "L'adresse est obligatoire")]
        public string Adresse { get; set; }
        [Required(ErrorMessage = "Le téléphone est obligatoire")]
        [RegularExpression(@"^(77|78|76)[0-9]{7}$", ErrorMessage = "Le téléphone doit commencer par 77 ou 78 ou 76 et doit avoir au 9 chiffres")]
        [UniqueTelephone]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Le solde est obligatoire")]
        // [Range(0.1, float.MaxValue, ErrorMessage = "Le solde doit être positif")]
        public float Solde { get; set; }
        public virtual ICollection<Commande>? Commandes { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}