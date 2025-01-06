using Microsoft.EntityFrameworkCore;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Data
{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commande>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Commandes)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.User)
                .WithOne(u => u.Client)
                .HasForeignKey<Client>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Commande)
                .WithMany(c => c.Details)
                .HasForeignKey(d => d.CommandeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Produit)
                .WithMany(c => c.Details)
                .HasForeignKey(d => d.ProduitId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Paiement>()
                .HasOne(p => p.Commande)
                .WithOne(c => c.Paiement)
                .HasForeignKey<Paiement>(p => p.CommandeId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Livraison>()
                .HasOne(l => l.Commande)
                .WithOne(c => c.Livraison)
                .HasForeignKey<Livraison>(l => l.CommandeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Livraison>()
                .HasOne(l => l.Livreur)
                .WithMany(l => l.Livraisons)
                .HasForeignKey(l => l.LivreurId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Livreur> Livreurs { get; set; }
    }
}