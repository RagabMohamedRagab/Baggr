using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Baggr.Providers.Entities.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public string ProductKey { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
