using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputerShop.Models;

namespace ComputerShop.Pages.Compatibles
{
    public class EditModel : PageModel
    {
        private readonly ComputerShop.Models.ShopContext _context;

        public EditModel(ComputerShop.Models.ShopContext context)
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
           ViewData["CompatibleProductId"] = new SelectList(_context.Product, "ID", "ID");
           ViewData["ProductId"] = new SelectList(_context.Product, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Compatible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompatibleExists(Compatible.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompatibleExists(int id)
        {
            return _context.Compatible.Any(e => e.ID == id);
        }
    }
}
