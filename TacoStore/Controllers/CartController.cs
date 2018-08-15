using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TacoStore.Models;

namespace TacoStore.Controllers
{
    public class CartController : Controller
    {
        //this is our DbContextObject
        private readonly TacoStoreDbContext _context;


        public CartController(TacoStoreDbContext context)
        {
            _context = context;


        }

        public IActionResult Index()
        {
            Guid cartId;
            Cart cart = null;



            return View();
        }
    }
}