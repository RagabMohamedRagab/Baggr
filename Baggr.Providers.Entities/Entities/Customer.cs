using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Baggr.Providers.Entities.Entities
{
    public class Customer
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CityKey { get; set; }
        public string Address { get; set; }
        public string ComesFrom { get; set; }
        public string MerchantKey { get; set; }
    }
}
