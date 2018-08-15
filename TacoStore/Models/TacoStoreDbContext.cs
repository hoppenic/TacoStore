using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TacoStore.Models;

namespace TacoStore.Models
{
    public class TacoStoreDbContext :IdentityDbContext<TacoStoreUser>
    {

        public TacoStoreDbContext() : base()
        {



        }


        public TacoStoreDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }

    public class TacoStoreUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class Cart
    {

        //constructor assigning hashset of class CartItem to a variable called CartItems
        public Cart()
        {
            var CartItems = new HashSet<CartItem>();
        }

        //Cart class properties
        public int ID { get; set; }
        public Guid CookieIdentifier { get; set; }
        public DateTime LastModified { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }


    public class CartItem
    {
        public int ID { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }






}
