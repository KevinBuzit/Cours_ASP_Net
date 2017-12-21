using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Produit
    {
        [Key]
        public int IDProduit { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public double? Prix { get; set; }
        public string Categorie { get; set; }

        public Produit( string nom, string descr, double? prix, string categorie)
        {
            this.Nom = nom;
            this.Description = descr;
            this.Prix = prix;
            this.Categorie = categorie;
        }

        public Produit()
        {

        }
    }
}
