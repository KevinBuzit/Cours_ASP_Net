﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.Models.ViewModels;

namespace ECommerce.Controllers
{
    public class ProduitController : Controller
    {
        private IProductRepository myObject;

        private const int pageSize = 5;

        public ProduitController(IProductRepository obj)
        {
            myObject = obj;
        }

        public ViewResult List(int? page, int? id)
        {
            if(id != null)
            {
                IQueryable<Produit> list = myObject.Produits().Where(t => t.IDProduit == id);
                PaginationInfo infos = new PaginationInfo(list.Count(), pageSize, 1);
                ListeProduitsViewModels viewModel = new ListeProduitsViewModels(list, infos);
                return View(viewModel);
            }
            else if(page != null)
            {
                IQueryable<Produit> list = myObject.Produits();
                PaginationInfo infos = new PaginationInfo(list.Count(), pageSize, page.Value);
                list = list.OrderBy(i => i.IDProduit).Skip((page.Value - 1) * pageSize).Take(pageSize);
                ListeProduitsViewModels viewModel = new ListeProduitsViewModels(list, infos);
                return View(viewModel);
            }
            else
            {
                PaginationInfo infos = new PaginationInfo(myObject.Produits().Count(), pageSize, 1);
                ListeProduitsViewModels viewModel = new ListeProduitsViewModels(myObject.Produits(), infos);
                return View(viewModel);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}