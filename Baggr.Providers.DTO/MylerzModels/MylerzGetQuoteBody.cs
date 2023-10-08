using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzGetQuoteBody
    {
        public string WarehouseName { get; set; }
        public string CustomerZoneCode { get; set; }
        public double PackageWeight { get; set; }
        public bool IsFulfillment { get; set; } = true;
        public string PackageServiceTypeCode { get; set; } = "DTD";
        public string PackageServiceCode { get; set; } = "ND";
        public string ServiceCategoryCode { get; set; } = "DELIVERY";
        public string PaymentTypeCode { get; set; } = "COD";
    }
}
