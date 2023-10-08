using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.FedexModels
{
    public class FedexShipmentCreationBody
    {
        public string UserName { get; set; } 
        public string Password { get; set; }
        public string AccountNo { get; set; }
        public AWBModel AirwayBillData { get; set; }
    }
}
