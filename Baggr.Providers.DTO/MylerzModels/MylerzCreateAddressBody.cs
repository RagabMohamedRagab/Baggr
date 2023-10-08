using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzCreateAddressBody
    {
        public int NumberOfnewwarehouse { get; set; } = 1;
        public int MemberId { get; set; } = 5538;
        public int MerchantId { get; set; } = 4562;
        public string MerchantName { get; set; } = "BAGGR";
        public string DisplayedName { get; set; } = "BAGGR";
        public string BankName { get; set; } = "Banque MIsr";
        public string BankAccountName { get; set; } = "Bagge for IT";
        public string BankAccountNumber { get; set; } = "1650001000003135";
        public int BusinessCategoryID { get; set; } = 2;
        public UserContact UserContact {get;set;}
        public IList<Warehouse> Warehouses { get; set; }
        public MylerzCreateAddressBody(Warehouse warehouse)
        {
            UserContact = new UserContact();
            Warehouses = new List<Warehouse>() { warehouse };
        }
    }
    public class UserContact
    {
        public string Username { get; set; } = "mohamed.ibrahim2";
        public int MemberID { get; set; } = 5538;
        public int MerchantId{ get; set; } = 4562;
        public int SubscriberId{ get; set; } =  8;
        public string Email{ get; set; } = "muhamedebrahim9 @gmail.com";
        public string Position{ get; set; } = "Owner";
        public string FullName{ get; set; } = "Muhamed Ebrahim ";
        public string MobileNo{ get; set; } = "01111616379";
        public string DisplayName{ get; set; } = "BAGGR";
    }
    
}
