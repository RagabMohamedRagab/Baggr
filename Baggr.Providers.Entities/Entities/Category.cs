using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Baggr.Providers.Entities.Entities
{
    public class Category
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public string MerchantKey { get; set; }
    }
}
