
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class GetQuoteDTO
    {
        public string ProviderKey { get; set; }
        public string ProviderName { get; set; }
        public string ProviderLogo { get; set; }
        public double TotalPrice { get; set; }
        public double BaggrFees { get; set; }
        public double ShippingFees { get; set; }
        public string ShippingFeesDetails { get; set; }
        public ProviderDTO Provider { get; set; }
        public GetQuoteDTO(string providerName, string providerLogo, double totalPrice, string provideKey, ProviderDTO provider)
        {
            ProviderName = providerName;
            ProviderLogo = providerLogo;
            TotalPrice = Math.Round(totalPrice + totalPrice / 1.14 * .2, 2) ;
            ShippingFees = totalPrice;
            ShippingFeesDetails = Math.Round(totalPrice / 1.14, 2).ToString() +"LE Shipping fees + "+ Math.Round(totalPrice / 1.14 * .14, 2)+"LE Shipping VAT + "+ Math.Round(totalPrice / 1.14 * .2, 2)+"LE Baggr fees";
            ProviderKey = provideKey;
            Provider = provider;
        }
    }
}
