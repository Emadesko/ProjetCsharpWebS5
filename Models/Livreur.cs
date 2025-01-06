using System.ComponentModel.DataAnnotations;
using ProjetCsharpWebS5.Validator;

namespace ProjetCsharpWebS5.Models
{
    public class Livreur {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Le téléphone est obligatoire")]
        [RegularExpression(@"^(77|78|76)[0-9]{7}$", ErrorMessage = "Le téléphone doit commencer par 77 ou 78 ou 76 et doit avoir au 9 chiffres")]
        [UniqueTelephone]
        public string Telephone { get; set; }
        public virtual ICollection<Livraison> Livraisons { get; set; }
    }
}