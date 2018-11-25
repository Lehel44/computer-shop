using ComputerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.DTO
{
    public class ProductOrderDTO
    {

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public ProductOrderDTO()
        {
        }

        public ProductOrderDTO(Product _Product, int _Quantity)
        {
            Product = _Product;
            Quantity = _Quantity;
            this.Price = this.Quantity * this.Product.Price;
        }
    }
}
