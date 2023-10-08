using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.FedexModels
{
    public class FedexGetPDFBody
    {
        public string UserName { get; set; } = "BAGGR";
        public string Password { get; set; } = "r9t4SiSiqY5WyUP99mt/8A==";
        public string AccountNo { get; set; } = "qb6gu/fdHAUpfk93HhpX2w==";
        public string AirwayBillNumber { get; set; }
    }
}
