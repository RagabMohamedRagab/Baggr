using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzShipment
    {
        public string WarehouseName { get; set; }
        public string PickupDueDate { get; set; } = DateTime.UtcNow.ToString();
        public string Package_Serial { get; set; }
        public string Description { get; set; }
        public string Total_Weight { get; set; }
        public string Service_Type { get; set; }="DTD";
        public string Service { get; set; }= "ND";
        public string Service_Category { get; set; }= "Delivery";
        public string Payment_Type { get; set; }= "COD";
        public string COD_Value { get; set; }
        public string Customer_Name { get; set; }
        public string Mobile_No { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Address_Category { get; set; }= "H";
        public string SpecialNotes { get; set; }
        public IList<Object> Pieces { get; set; } = new List<Object>() { new { PieceNo = 1 } };

    }
}
