using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComputerShop.Models;

namespace ComputerShop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext (DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<ComputerShop.Models.Product> Product { get; set; }

        public DbSet<ComputerShop.Models.Customer> Customer { get; set; }

        public DbSet<ComputerShop.Models.Category> Category { get; set; }

        public DbSet<ComputerShop.Models.Order> Order { get; set; }

        public DbSet<ComputerShop.Models.OrderItem> OrderItem { get; set; }

        public DbSet<ComputerShop.Models.Compatible> Compatible { get; set; }
    }
}
