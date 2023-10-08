using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzCreateAddressResponse
    {
        public bool IsErrorState { get; set; }
        public string ErrorDescription { get; set; }
        public IList<Warehouse> Value { get; set; }
    }
}
