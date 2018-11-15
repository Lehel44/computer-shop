using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ComputerShop.Models;

namespace ComputerShop.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ComputerShop.Models.ShopContext _context;

        public IndexModel(ComputerShop.Models.ShopContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order.ToListAsync();
        }
    }
}
