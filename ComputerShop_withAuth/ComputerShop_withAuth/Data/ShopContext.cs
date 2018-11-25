using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComputerShop_withAuth.Models;

namespace ComputerShop_withAuth.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext (DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<ComputerShop_withAuth.Models.Product> Product { get; set; }

        public DbSet<ComputerShop_withAuth.Models.Customer> Customer { get; set; }

        public DbSet<ComputerShop_withAuth.Models.Category> Category { get; set; }

        public DbSet<ComputerShop_withAuth.Models.Order> Order { get; set; }

        public DbSet<ComputerShop_withAuth.Models.OrderItem> OrderItem { get; set; }

        public DbSet<ComputerShop_withAuth.Models.Compatible> Compatible { get; set; }
    }
}
