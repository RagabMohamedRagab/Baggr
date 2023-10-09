using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities.Entities {
    public class JTExpressCity {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int? JTExpressZoneId { get; set; }
        public virtual JTExpressZone JTExpressZone { get; set; }    
    }
}
