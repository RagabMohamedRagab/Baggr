using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities.Entities
{
    public class ProviderInformation
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public string Info { get; set; }
    }
}
