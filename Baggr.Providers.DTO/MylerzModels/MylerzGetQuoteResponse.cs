using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzGetQuoteResponse
    {
        public Value Value { get; set; }
        public bool IsErrorState { get; set; }
        public string ErrorDescription { get; set; }
    }
    public class Value
    {
        public double NetTransferValue { get; set; }
    }
}
