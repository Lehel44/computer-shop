using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ComputerShop_withAuth.Models;

namespace ComputerShop_withAuth.Pages.Compatibles
{
    public class IndexModel : PageModel
    {
        private readonly ComputerShop_withAuth.Models.ShopContext _context;

        public IndexModel(ComputerShop_withAuth.Models.ShopContext context)
        {
            _context = context;
        }

        public IList<Compatible> Compatible { get;set; }

        public async Task OnGetAsync()
        {
            Compatible = await _context.Compatible
                .Include(c => c.CompatibleProduct)
                .Include(c => c.Product).ToListAsync();
        }
    }
}
