using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ProjetCsharpWebS5.Validator;

namespace ProjetCsharpWebS5.Models
{
    public class Produit {
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Le libelle doit avoir au moins 2 caractères et inférieur à 20 caractères")]
        [UniqueLibelle]
        [Required(ErrorMessage = "Le libelle est obligatoire")]
        public string Libelle { get; set; }
        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0, float.MaxValue, ErrorMessage = "Le prix doit être positif")]
        public float Prix { get; set; }
        [Required(ErrorMessage = "La quantité en stock est obligatoire")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantité en stock doit être positif")]
        public int QteStock { get; set; }
        [Required(ErrorMessage = "La quantité ceuille est obligatoire")]
        [Range(5, int.MaxValue, ErrorMessage = "La quantité ceuille doit dépasser 5")]
        public int QteCeuil { get; set; }
        [JsonIgnore]
        public virtual ICollection<Detail>? Details { get; set; }
        
    }
}