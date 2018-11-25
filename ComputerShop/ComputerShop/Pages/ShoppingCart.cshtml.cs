using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop.DTO;
using ComputerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ComputerShop.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly ShopContext context;
        private readonly ISession session;
        private const String CART_KEY = "cart";

        public List<ProductOrderDTO> ShoppingCartData { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public ShoppingCartModel(ShopContext _context, IHttpContextAccessor httpContextAccessor)
        {
            context = _context;
            session = httpContextAccessor.HttpContext.Session;
            ShoppingCartData = new List<ProductOrderDTO>();
            Customer = new Customer();
        }

        public void OnGet()
        {
            ShoppingCartData = ShoppingCartDTO.Cart;
        }
        // disable ...
        public IActionResult OnPost()
        {
            // Add customer to databse if hasn't ordered anything yet.

            //context.Customer.Add(Customer);
            //context.SaveChanges();

            // Create an order
            Order order = new Order();
            order.Date = DateTime.Today;

            Customer.Orders.Add(order);
            context.Order.Add(order);
           
            //context.SaveChanges();

            // Create the orderitems
            foreach (ProductOrderDTO dto in ShoppingCartDTO.Cart)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.order = order;
                orderItem.product = dto.Product;
                orderItem.quantity = dto.Quantity;
                order.OrderItems.Add(orderItem);
            }

            

            // Empty the cart.
            ShoppingCartDTO.Cart.Clear();
            session.Remove("cart");

            return RedirectToAction("OnGet");
        }

        public IActionResult OnPostEmptyCart()
        {
            ShoppingCartDTO.Cart.Clear();
            session.Remove("cart");
            return RedirectToAction("OnGet");
        }
    }
}