using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ComputerShop.Models;

namespace ComputerShop.Pages.Compatibles
{
    public class DeleteModel : PageModel
    {
        private readonly ComputerShop.Models.ShopContext _context;

        public DeleteModel(ComputerShop.Models.ShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Compatible Compatible { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Compatible = await _context.Compatible
                .Include(c => c.CompatibleProduct)
                .Include(c => c.Product).FirstOrDefaultAsync(m => m.ID == id);

            if (Compatible == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Compatible = await _context.Compatible.FindAsync(id);

            if (Compatible != null)
            {
                _context.Compatible.Remove(Compatible);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
