using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop_withAuth.Models
{
    public class Compatible
    {
        public int ID { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("CompatibleProduct")]
        public int? CompatibleProductId { get; set; }
        public Product CompatibleProduct { get; set; }
    }
}
