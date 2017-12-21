using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class FauxDepotProduit : IProductRepository
    {
        private List<Produit> listeProduit = new List<Produit>();

        public FauxDepotProduit()
        {
            Produit p1 = new Produit("Nintendo Switch","Console portable de Nintendo",300,"Console");
            Produit p2 = new Produit("PS4", "Console de sony", 250, "Console");
            Produit p3 = new Produit("Wimote", "Manette de switch", 20, "Accessoire console");
            Produit p4 = new Produit("Pochette", "Pochette de console switch", 15, "Accessoire console");

            listeProduit.Add(p1);
            listeProduit.Add(p2);
            listeProduit.Add(p3);
            listeProduit.Add(p4);
        }

        public IQueryable<Produit> Produits()
        {
            return listeProduit.AsQueryable();
        }

        public void AddProduit(Produit prod)
        {
            listeProduit.Add(prod);
        }
    }
}
