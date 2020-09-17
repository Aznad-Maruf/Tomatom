using Ecommerce.Model.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Model.HelpingModels;

namespace Ecommerce.Database
{
    public class EcommerceDbContext:DbContext
    {
        public EcommerceDbContext(DbContextOptions options):base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
