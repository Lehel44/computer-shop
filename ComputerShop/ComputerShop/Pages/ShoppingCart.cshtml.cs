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

        public List<ShoppingCartDTO> ShoppingCartData { get; set; }

        public ShoppingCartModel(ShopContext _context, IHttpContextAccessor httpContextAccessor)
        {
            context = _context;
            session = httpContextAccessor.HttpContext.Session;
            ShoppingCartData = new List<ShoppingCartDTO>();
        }

        public void OnGet()
        {
            IEnumerable<string> keystrings = session.Keys;
            if (keystrings.Count() != 0)
            {
                foreach (string key in keystrings)
                {
                    ShoppingCartDTO dto = JsonConvert.DeserializeObject<ShoppingCartDTO>(session.GetString(key));
                    ShoppingCartData.Add(dto);
                }
            }
            

        }
    }
}