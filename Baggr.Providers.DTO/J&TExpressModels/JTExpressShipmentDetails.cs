using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressShipmentDetails
    {
        public string ExpressType { get; set; } = "EZ";
        public string DeliveryType { get; set; } = "04";

        public string PayType { get; set; } = "PP_CASH";
      
        public string GoodsType { get; set; } = "ITN16";
        public int TotalQuantity { get; set; } = 1;

        public decimal Weight { get; set; }
        // public string fodMoney { get; set; } = "";
        public string priceCurrency { get; set; } = "EGP";

        public int OperateType { get; set; } = 1;

        public string Remark { get; set; }

        //public int OfferFee { get; set; }
        public string EXDRDescription { get; set; }

       
    }
}
