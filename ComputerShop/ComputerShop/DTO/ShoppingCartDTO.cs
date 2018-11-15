using ComputerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.DTO
{
    public class ShoppingCartDTO
    {
        public Product Product { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        public ShoppingCartDTO()
        {
        }

        public ShoppingCartDTO(Product _Product, int _quantity)
        {
            Product = _Product;
            quantity = _quantity;
            this.price = this.quantity * this.Product.Price;
        }
    }
}
