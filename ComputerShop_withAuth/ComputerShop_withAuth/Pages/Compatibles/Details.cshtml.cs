﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ComputerShop_withAuth.Models;

namespace ComputerShop_withAuth.Pages.Compatibles
{
    public class DetailsModel : PageModel
    {
        private readonly ComputerShop_withAuth.Models.ShopContext _context;

        public DetailsModel(ComputerShop_withAuth.Models.ShopContext context)
        {
            _context = context;
        }

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
    }
}
