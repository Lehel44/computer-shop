using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop_withAuth.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // navigation properties
        public ICollection<Product> Products { get; set; }
    }
}
