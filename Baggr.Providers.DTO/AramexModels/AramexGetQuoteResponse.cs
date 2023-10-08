using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    
        public class AramexGetQuoteResponse
        {
        public AramexTotalAmount TotalAmount { get; set; }
    }
    
        public class AramexTotalAmount
        {
            public double Value { get; set; }
        }
    
}
