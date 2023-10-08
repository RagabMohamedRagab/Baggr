using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressItem
    {
        
        public int ? Number { get; set; }=null; 
        public string ItemType { get; set; } = "";
        public string ItemName { get; set; } = "";
        public string PriceCurrency { get; set; } = "EGP";
        public string ItemValue { get; set; } = "";
        public string ChineseName { get; set; } = "";
        public string EnglishName { get; set; } = "";
        public string ItemUrl { get; set; } = "";
        public string Itemdesc { get; set; } = "";


    }
}
