using System.Threading.Tasks;
using ComputerShop_withAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ComputerShop_withAuth.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ComputerShop_withAuth.Models.ShopContext _context;

        public CreateModel(ComputerShop_withAuth.Models.ShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}