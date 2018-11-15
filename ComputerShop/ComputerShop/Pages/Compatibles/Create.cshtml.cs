using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ComputerShop.Models;

namespace ComputerShop.Pages.Compatibles
{
    public class CreateModel : PageModel
    {
        private readonly ComputerShop.Models.ShopContext _context;

        public CreateModel(ComputerShop.Models.ShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CompatibleProductId"] = new SelectList(_context.Product, "ID", "ID");
        ViewData["ProductId"] = new SelectList(_context.Product, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Compatible Compatible { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Compatible.Add(Compatible);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}