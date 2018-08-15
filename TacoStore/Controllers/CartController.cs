using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TacoStore.Models;
using Microsoft.EntityFrameworkCore;


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
            if (Request.Cookies.ContainsKey("cartId"))
            {
                if(Guid.TryParse(Request.Cookies["cartId"],out cartId))
                {
                    cart = _context.Carts
                        .Include(Carts => Carts.CartItems)
                        .ThenInclude(CartItems => CartItems.Product)
                        .FirstOrDefault(x => x.CookieIdentifier == cartId);
                }
            }
            if (cart == null)
            {
                cart = new Cart();
            }


            return View(cart);
        }


        public IActionResult Remove(int id)
        {
            Guid cartId;
            Cart cart = null;

            if (Request.Cookies.ContainsKey("cartId"))
            {
                if(Guid.TryParse(Request.Cookies["cartId"],out cartId))
                {
                    cart = _context.Carts
                        .Include(Carts => Carts.CartItems)
                        .ThenInclude(CartItems => CartItems.Product)
                        .FirstOrDefault(x => x.CookieIdentifier == cartId);
                }
            }

            CartItem item = cart.CartItems.FirstOrDefault(x => x.ID == id);
            cart.LastModified = DateTime.Now;

            _context.CartItems.Remove(item);

            _context.SaveChanges();

            return RedirectToAction("Index");






        }
    }
}