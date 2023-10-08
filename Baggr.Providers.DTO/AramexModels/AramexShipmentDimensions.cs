using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexShipmentDimensions
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Unit { get; set; } = "";
    }
}
