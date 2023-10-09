using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs {
    public class JTExpressZonesPageDTO {
        public int TotalCount { get; set; }
        public int PagesCount { get; set; }
        public IList<JTExpressZoneDTO> CityDTOs { get; set; }
    }
}
