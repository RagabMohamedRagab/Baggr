using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities.Entities {
   

    public class JTExpressZone {
        public int Id { get; set; }

        public string Name { get; set; }   
        public decimal Price { get; set; }

        public decimal PriceChangeRatio { get; set; }

        public virtual ICollection<JTExpressCity> JTExpressCities { get; set; }
    }

}
