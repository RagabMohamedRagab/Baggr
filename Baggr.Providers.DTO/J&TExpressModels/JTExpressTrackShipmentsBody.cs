using Baggr.Providers.DTO.AramexModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressTrackShipmentsBody
    {
        
        public IEnumerable<string> billCodes { get; set; }
        public JTExpressTrackShipmentsBody(IEnumerable<string> billcode)
        {
            billCodes = billcode;
           
        }
    }
}
