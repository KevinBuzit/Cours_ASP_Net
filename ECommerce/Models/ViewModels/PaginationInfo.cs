using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class PaginationInfo
    {
        private int NombreProduits { get; set; }
        private int ProduitsParPage { get; set; }
        private int PageCourante { get; set; }

        public PaginationInfo(int _nombreProduit, int _produitParPage, int _pageCourante)
        {
            NombreProduits = _nombreProduit;
            ProduitsParPage = _produitParPage;
            PageCourante = _pageCourante;
        }

        public int GetNombrePage()
        {
            double doubleValue = Convert.ToDouble(NombreProduits) / ProduitsParPage;
            int res = Convert.ToInt32(Math.Ceiling(doubleValue));
            return res;
        }
    }
}
