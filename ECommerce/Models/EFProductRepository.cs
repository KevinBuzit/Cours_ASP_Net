using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        IQueryable<Produit> IProductRepository.Produits()
        {
            return context.Produits;
        }
    }
}
