using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class ProviderDTO
    {
        public string Key { get; set; }
        public string ProviderName { get; set; }
        public string ProviderLogo { get; set; }
        public string ProviderAnalyticsColour { get; set; }
        public IEnumerable<ProviderInformationDTO> ProviderInformation { get; set; }
    }
}
