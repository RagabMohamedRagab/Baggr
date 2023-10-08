using Baggr.Providers.DTO.AramexModels;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels {
    public class JTExpressShipment {

        //mearshant num 
        public JTExpressPersonDetails Shipper { get; set; }   
        public JTExpressPersonDetails Consignee { get; set; }
        public JTExpressItem Items { get; set; }
        
        public string CustomerCode {  get; set; }
        public string Digest { get; set; }
        public string BillCode { get; set; }
        public string TxlogisticId { get; set; }
        public string SendStartTime { get; set; } = "";
        public string SendEndTime { get; set; } = "";
        public JTExpressShipmentDetails ShipmentDetails { get; set; }

        public JTExpressShipment()
        {
            CustomerCode = JTExpressClientInfo.CustomerCode;
            Digest=JTExpressShipmentDegistBody.CalculateDigest();
           
            Random random = new Random();

            TxlogisticId= random.Next(10000000, 1000000000).ToString();

        }

    }
}
