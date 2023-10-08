using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class Warehouse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool change { get; set; } = true;
        public int SubZoneId { get; set; }
        public string Address { get; set; }
        public int HubId { get; set; } = 0;
        public string PhoneNumber { get; set; }
        public string ContactName { get; set; }
        public Warehouse(string name, string address, string phoneNumber = null, string contactName = null)
        {
            Name = name +"-"+ Guid.NewGuid().ToString();
            Address = address+"-" + Guid.NewGuid().ToString();
            PhoneNumber = phoneNumber;
            ContactName = contactName;
        }
    }
}
