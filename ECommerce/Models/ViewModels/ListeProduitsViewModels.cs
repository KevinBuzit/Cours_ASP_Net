using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ListeProduitsViewModels
    {
        private IQueryable<Produit> listeProduits { get; set; }
        private PaginationInfo PaginationInfos { get; set; }

        public ListeProduitsViewModels(IQueryable<Produit> _produits, PaginationInfo _info)
        {
            listeProduits = _produits;
            PaginationInfos = _info;
        }
    }
}
