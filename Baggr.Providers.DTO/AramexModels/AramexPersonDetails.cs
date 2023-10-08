using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexPersonDetails
    {
        public string AccountNumber { get; set; }
        public AramexAddress PartyAddress { get; set; }
        public AramexContact Contact { get; set; }
    }
}
