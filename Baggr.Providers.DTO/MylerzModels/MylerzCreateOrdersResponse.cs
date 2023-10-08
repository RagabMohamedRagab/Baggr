using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzCreateOrdersResponse
    {
        public MylerzOrderResponseValue Value { get; set; }
        public bool IsErrorState { get; set; }
        public string ErrorMessage { get; set; }

    }
    public class MylerzOrderResponseValue
    {
        public IList<MylerzPackage> Packages { get; set; }
    }
}
