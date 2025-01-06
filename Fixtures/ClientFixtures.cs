using ProjetCsharpWebS5.Data;
using ProjetCsharpWebS5.Enums;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Fixtures
{
    public class ClientFixtures
    {
        private readonly ApplicationDbContext _context;

        public ClientFixtures(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Load()
        {
            if (!_context.Produits.Any())
            {
                _context.Produits.AddRange(
                    new Produit
                    {
                        Libelle = "Lait",
                        Prix = 600,
                        QteStock = 40,
                        QteCeuil = 20,
                    },
                    new Produit
                    {
                        Libelle = "Sucre",
                        Prix = 650,
                        QteStock = 100,
                        QteCeuil = 20,
                    },
                    new Produit
                    {
                        Libelle = "Riz",
                        Prix = 400,
                        QteStock = 15,
                        QteCeuil = 20,
                    },
                    new Produit{
                        Libelle = "Eau",
                        Prix = 500,
                        QteStock = 200,
                        QteCeuil = 20,
                    },
                    new Produit{
                        Libelle = "Pain",
                        Prix = 800,
                        QteStock = 30,
                        QteCeuil = 20,
                    },
                    new Produit{
                        Libelle = "Chips",
                        Prix = 300,
                        QteStock = 50,
                        QteCeuil = 20,
                    },
                    new Produit{
                        Libelle = "Chocolat",
                        Prix = 550,
                        QteStock = 80,
                        QteCeuil = 20,
                    },
                    new Produit{
                        Libelle = "Pizza",
                        Prix = 1200,
                        QteStock = 20,
                        QteCeuil = 20,
                    },
                    new Produit{
                        Libelle = "Boisson",
                        Prix = 450,
                        QteStock = 100,
                        QteCeuil = 20,
                    },
                    new Produit{
                        Libelle = "Café",
                        Prix = 600,
                        QteStock = 50,
                        QteCeuil = 20,
                    }


                );

                _context.SaveChanges();
            }

            if (!_context.Clients.Any())
            {
                _context.Clients.AddRange(
                    new Client
                    {
                        Nom= "John Doe",
                        Prenom= "John Doe",
                        Telephone = "771234567",
                        Adresse = "123 Rue des Bleus",
                        User = new User
                        {
                            Login = "john.doe",
                            Password = "password",
                            Role = "Client"
                        }
                    },
                    new Client
                    {
                        Nom = "Jane Smith",
                        Prenom = "Jane Smith",
                        Telephone = "789654321",
                        Adresse = "456 Rue des Verts",
                        User = new User
                        {
                            Login = "Jane.doe",
                            Password = "password",
                            Role = "Client"
                        }
                    },
                    new Client
                    {
                        Nom = "Alice Johnson",
                        Prenom = "Alice Johnson",
                        Telephone = "761472583",
                        Adresse = "789 Rue des Gris",
                        User = new User
                        {
                            Login = "Alice.doe",
                            Password = "password",
                            Role = "Client"
                        }
                    },
                    new Client{
                        Nom = "Bob Wilson",
                        Prenom = "Bob Wilson",
                        Telephone = "770876543",
                        Adresse = "234 Rue des Rouges",
                        User = new User
                        {
                            Login = "bob.doe",
                            Password = "password",
                            Role = "Client"
                        }
                    },
                    new Client{
                        Nom = "Emily Davis",
                        Prenom = "Emily Davis",
                        Telephone = "789012345",
                        Adresse = "345 Rue des Noirs",
                        User = new User
                        {
                            Login = "emily.doe",
                            Password = "password",
                            Role = "Client"
                        }
                    },
                    new Client{
                        Nom = "Michael Brown",
                        Prenom = "Michael Brown",
                        Telephone = "765432109",
                        Adresse = "678 Rue des Blues",
                        User = new User
                        {
                            Login = "michael.doe",
                            Password = "password",
                            Role = "Client"
                        }
                    }
                );

                _context.SaveChanges();
            }

            if (!_context.Commandes.Any())
            {
                Random rand = new Random();
                for (int i = 0; i < 40; i++)
                {
                    ICollection<Detail> details = new List<Detail>();
                    for (int x = 1; x <= rand.Next(1,11); x++)
                    {
                        details.Add(
                            new Detail{
                                Produit = _context.Produits.Find(x)!,
                                Prix = _context.Produits.Find(x)!.Prix,
                                Qte = rand.Next(1,10),
                            }
                        );
                    }
                    Array valeurs = Enum.GetValues(typeof(EtatCommande));
                    EtatCommande etatCommande = (EtatCommande)valeurs.GetValue(rand.Next(valeurs.Length));
                    _context.Commandes.Add(
                        new Commande{
                            Client = _context.Clients.Find(rand.Next(1,7))!,
                            Montant = (float) (rand.NextDouble() * (100000.0 - 1000.0) - 1000.0),
                            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(rand.Next(0,10))),
                            Etat = etatCommande,
                            Details = details
                        }
                    );
                }
                _context.SaveChanges();
            }

        }
    }

}