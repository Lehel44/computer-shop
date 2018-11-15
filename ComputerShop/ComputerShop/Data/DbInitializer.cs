using ComputerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Data
{
    public class DbInitializer
    {
        public static void Initialize(ShopContext context)
        {
            context.Database.EnsureCreated();

            if (context.Product.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
                new Category{Name = "VGA"},
                new Category{Name = "CPU"},
                new Category{Name = "Memory"},
                new Category{Name = "Monitor"},
                new Category{Name = "Motherboard"}
            };
            foreach (Category c in categories)
            {
                context.Category.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{Name = "Gigabyte Geforce GTX 1050 Ti", Price = 55865, Color = "black", CategoryID = 1},
                new Product{Name = "SAPPHIRE Radeon RX 580 NITRO+", Price = 89540, Color = "black", CategoryID = 1},
                new Product{Name = "Intel Core i7 8700K", Price = 137280, Color = "gray", CategoryID = 2},
                new Product{Name = "Intel i9-9900K Octa-Core 3.6GHz LGA1151", Price = 199900, Color = "gray", CategoryID = 2},
                new Product{Name = "AMD Ryzen 5 2600 Hexa-Core 3.4Ghz AM4", Price = 52536, Color = "gray", CategoryID = 2},
                new Product{Name = "G.SKILL Aegis 16GB DDR4 3000MHz", Price = 43190, Color = "black", CategoryID = 3},
                new Product{Name = "Kingston 8GB DDR3 1600MHz", Price = 17610, Color = "green", CategoryID = 3},
                new Product{Name = "Acer Predator XB241Hbmipr", Price = 129990, Color = "red", CategoryID = 4},
                new Product{Name = "Dell Alienware AW2518HF", Price = 99677, Color = "red", CategoryID = 4},
                new Product{Name = "ASUS ROG STRIX B250G GAMING", Price = 26970, Color = "black", CategoryID = 5},
                new Product{Name = "ASUS ROG RAMPAGE VI EXTREME", Price = 198000, Color = "black", CategoryID = 5},
                new Product{Name = "MSI B350 GAMING PRO CARBON", Price = 37235, Color = "black", CategoryID = 5}
                
            };
            foreach (Product p in products)
            {
                context.Product.Add(p);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{Name = "Molnár Péter", Email = "peter.molnar@gmail.com", Phone = "06304567281"},
                new Customer{Name = "Hegedűs Ildikó", Email = "ildi.hegedus88@gmail.com", Phone = "06208587222"},
                new Customer{Name = "Szalai András", Email = "szalai.andras20@hotmail.com", Phone = "06708827281"}
            };
            foreach (Customer c in customers)
            {
                context.Customer.Add(c);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{CustomerID = 1, Date = DateTime.Parse("2018-09-01")},
                new Order{CustomerID = 2, Date = DateTime.Parse("2018-10-11")},
                new Order{CustomerID = 2, Date = DateTime.Parse("2018-11-05")}
            };
            foreach (Order o in orders)
            {
                context.Order.Add(o);
            }
            context.SaveChanges();

            var orderitems = new OrderItem[]
            {
                new OrderItem {OrderID = 1, ProductID = 1, quantity = 1},
                new OrderItem {OrderID = 1, ProductID = 4, quantity = 1},
                new OrderItem {OrderID = 2, ProductID = 4, quantity = 1},
                new OrderItem {OrderID = 2, ProductID = 2, quantity = 2},
                new OrderItem {OrderID = 3, ProductID = 3, quantity = 5}
            };

            foreach (OrderItem oi in orderitems)
            {
                context.OrderItem.Add(oi);
            }
            context.SaveChanges();

            var compatibles = new Compatible[]
            {
                new Compatible{Product = products[2], CompatibleProduct = products[9]},
                new Compatible{Product = products[9], CompatibleProduct = products[2]},
                new Compatible{Product = products[2], CompatibleProduct = products[10]},
                new Compatible{Product = products[10], CompatibleProduct = products[2]},
                new Compatible{Product = products[9], CompatibleProduct = products[6]},
                new Compatible{Product = products[6], CompatibleProduct = products[9]},
                new Compatible{Product = products[9], CompatibleProduct = products[1]},
                new Compatible{Product = products[1], CompatibleProduct = products[9]},
                new Compatible{Product = products[1], CompatibleProduct = products[8]},
                new Compatible{Product = products[8], CompatibleProduct = products[1]}
            };

            foreach (Compatible c in compatibles)
            {
                context.Compatible.Add(c);
            }
            context.SaveChanges();
        }
    }

}
