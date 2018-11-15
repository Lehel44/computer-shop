using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int quantity { get; set; }

        // foreign keys
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }

        // navigation properties
        public Product product { get; set; }
        public Order order { get; set; }
    }
}
