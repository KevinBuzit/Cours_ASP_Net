using ECommerce.Models;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ECommerce
{
    public class SeedData
    {
        public static void ImplementDatabase(IApplicationBuilder appBuilder)
        {
            // Récupération du contexte bdd
            ApplicationDbContext context = appBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            // Migration afin de pouvoir ajouter des données
            context.Database.Migrate();

            // Vérification si il n'y a pas un context existant avec des produits initialisé
            if(!context.Produits.Any())
            {
                // Construction de l'ensemble des produits
                context.Produits.AddRange(
                        new Produit("Nintendo Switch", "Console portable de Nintendo", 300, "Console"),
                        new Produit("PS4", "Console de sony", 250, "Console"),
                        new Produit("Wimote", "Manette de switch", 20, "Accessoire console"),
                        new Produit("Pochette", "Pochette de console switch", 15, "Accessoire console"),
                        new Produit("Pop Mario", "Figurine Mario rouge", 20, "Figurine"),
                        new Produit("Pop Bowser", "Figurine Bowser en costume", 20, "Figurine"),
                        new Produit("Chargeur switch", "Chargeur pour console switch", 50, "Accessoire console"),
                        new Produit("Support console switch", "Support transmetteur pour switch", 20, "Accessoire console"),
                        new Produit("Autocollant Lapin Cretin", "Lapin crétin batiment", 15, "Autocollant"),
                        new Produit("Autocollant Rox", "Rox", 15, "Autocollant")
                    );

                context.SaveChanges();
            }
        }
    }
}
