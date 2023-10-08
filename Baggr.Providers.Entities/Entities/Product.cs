using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Baggr.Providers.Entities.Entities
{
    public class Product
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string SKU { get; set; }
        public int StockAvailability { get; set; }
        public string PhotoUrl { get; set; }
        [Required]
        [ForeignKey("Category")]
        public string CategoryKey { get; set; }
        public virtual Category Category { get; set; }
        public string MerchantKey { get; set; }
        public bool IsDeleted { get; set; }

    }
}
