using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }

        // foreing keys
        [ForeignKey("Category")]
        public int CategoryID;

        // navigation properties
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        /*[InverseProperty("FirstProduct")]
        public ICollection<Compatible> FirstProducts { get; set; }*/
        [InverseProperty("CompatibleProduct")]
        public ICollection<Compatible> CompatibleProducts { get; set; }
    }
}
