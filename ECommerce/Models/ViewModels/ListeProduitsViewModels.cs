using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ListeProduitsViewModels
    {
        public IQueryable<Produit> ListeProduits { get; set; }
        public PaginationInfo PaginationInfos { get; set; }

        public ListeProduitsViewModels(IQueryable<Produit> _produits, PaginationInfo _info)
        {
            ListeProduits = _produits;
            PaginationInfos = _info;
        }
    }
}
