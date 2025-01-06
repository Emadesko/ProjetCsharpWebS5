using System.ComponentModel.DataAnnotations;
using ProjetCsharpWebS5.Enums;

namespace ProjetCsharpWebS5.Models
{
    public class Paiement {
        public int Id { get; set; }
        [Required(ErrorMessage = "La date est obligatoire")]
        public DateOnly Date { get; set; }
        [Required(ErrorMessage = "Le montant est obligatoire")]
        public float Montant { get; set; }
        public string Numero { get; set; }
        [Required(ErrorMessage = "La référence est obligatoire")]
        public string Reference { get; set; }
        [Required(ErrorMessage = "Le type est obligatoire")]
        public TypePaiement Type { get; set; }
        public int CommandeId { get; set; }
        public virtual Commande Commande { get; set; }
    }
}