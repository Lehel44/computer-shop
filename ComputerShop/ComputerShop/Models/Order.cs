using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int? Price { get; set; }

        // foreign keys
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        // navigation properties
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
