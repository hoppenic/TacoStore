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
        private List<Product> _products;


        public ProductController()
        {
            _products = new List<Product>();

            _products.Add(new Product
            {
                ID=1,
                Name="Chicken Taco",
                Description="Slow cooked shredded chicken thighs",
                Price=2.99m


            });

            _products.Add(new Product
            {
                ID=2,
                Name="Carnitas Taco",
                Description="Slow cooked pork with pineapple",
                Price=1.99m

            });

            _products.Add(new Product
            {
                ID = 3,
                Name = "Barbacoa Taco",
                Description = "Slowly Cooked Beef w/Spices",
                Price = 2.99m


            });

        }

        public IActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Product p = _products.Single(x => x.ID == id.Value);
                return View(p);
            }

            return NotFound();
        }

        public IActionResult Index()
        {
            return View(_products);
        }
    }
}