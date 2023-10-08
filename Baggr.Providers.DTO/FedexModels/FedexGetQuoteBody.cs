using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.FedexModels
{
    public class FedexGetQuoteBody
    {
        public string UserName { get; set; } = "BAGGR";
        public string Password { get; set; } = "r9t4SiSiqY5WyUP99mt/8A==";
        public string Destination { get; set; } = "CAI";
        public string Dimension { get; set; } = "1X1X1";
        public string Origin { get; set; } = "CAI";
        public string PaymentMethod { get; set; } = "AC";
        public string ServiceType { get; set; } = "DOX";
        public string Product { get; set; } = "DOX";
        public double Weight { get; set; } 
        public int NoofPeices { get; set; } = 1;

}
}
