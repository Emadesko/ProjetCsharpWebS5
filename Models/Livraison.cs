namespace ProjetCsharpWebS5.Models
{
    public class Livraison {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string Adresse { get; set; }
        public int CommandeId { get; set; }
        public virtual Commande Commande { get; set; }
        public int LivreurId { get; set; }
        public virtual Livreur Livreur { get; set; }
    }
}