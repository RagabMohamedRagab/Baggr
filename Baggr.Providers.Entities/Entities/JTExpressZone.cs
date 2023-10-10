using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities.Entities {
   

    public class JTExpressZone {
        public int Id { get; set; }

        public string Name { get; set; }   
        public double Price { get; set; }

        public double PriceChangeRatio { get; set; }

        public virtual ICollection<JTExpressCity> JTExpressCities { get; set; }
    }

}
