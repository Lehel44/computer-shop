using ComputerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.DTO
{

    public class ShoppingCartDTO
    {
        public static List<ProductOrderDTO> Cart { get; set; } = new List<ProductOrderDTO>();

        public ShoppingCartDTO()
        {
        }

        public ShoppingCartDTO(ProductOrderDTO ProductOrderDto)
        {
            Cart.Add(ProductOrderDto);
        }

        public void Add(ProductOrderDTO ProductOrderDto)
        {
            Cart.Add(ProductOrderDto);
        }

        public void ClearCart()
        {
            Cart.Clear();
        }
    }
}
