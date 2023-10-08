using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.FetchrModels
{
    public class FetchrConfig
    {
        public double AddedTaxes { get; set; }
        public int RatePerExtraKG { get; set; }
        public List<FetcherRatePerKG> RatePerFirstKG { get; set; }
    }
    public class FetcherRatePerKG
    {
        public string Destination { get; set; }
        public int Price { get; set; }
    }
}
