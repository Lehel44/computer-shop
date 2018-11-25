using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShop_withAuth.DTO;
using ComputerShop_withAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ComputerShop_withAuth.Pages.Products
{

    public class AddToCartModel : PageModel
    {
        private readonly ShopContext _context;
        private readonly ISession session;

        public AddToCartModel(ShopContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            session = httpContextAccessor.HttpContext.Session;
        }

        public Product Product { get; set; }
        [BindProperty]
        public int quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (quantity == 0)
            {
                return Page();
            }
            Product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);
            var ProductOrderDto = new ProductOrderDTO(Product, quantity);
            var data = JsonConvert.SerializeObject(new ShoppingCartDTO(ProductOrderDto));
            session.SetString("cart", data);

            return Page();
        }
    }
}