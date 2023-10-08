using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzGetPDFBody
    {
        public string Barcode { get; set; }
        public MylerzGetPDFBody(string AWB)
        {
            Barcode = AWB;
        }
    }
}
