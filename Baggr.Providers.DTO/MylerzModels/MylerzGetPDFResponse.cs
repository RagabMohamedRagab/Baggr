using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzGetPDFResponse
    {
        public string Value { get; set; }
        public bool IsErrorState { get; set; }
        public string ErrorMessage { get; set; }
    }
}
