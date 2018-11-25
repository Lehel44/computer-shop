using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ComputerShop_withAuth.Models;
using Microsoft.AspNetCore.Authorization;

namespace ComputerShop_withAuth.Pages.Categories
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ComputerShop_withAuth.Models.ShopContext _context;

        public IndexModel(ComputerShop_withAuth.Models.ShopContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
