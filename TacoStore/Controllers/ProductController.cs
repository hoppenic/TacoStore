using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TacoStore.Models;

namespace TacoStore.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly TacoStoreDbContext _context;

        public ProductController(TacoStoreDbContext context)
        {
            _context = context;           

        }


        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Product p = _context.Products.Find(id.Value);
                return View(p);
            }

            return NotFound();
        }


    }

    

     
}