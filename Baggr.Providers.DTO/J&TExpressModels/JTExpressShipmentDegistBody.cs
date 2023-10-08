using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    //DegistBody=base64(md5(customer number + cipher text + privateKey)).
    public  class JTExpressShipmentDegistBody
    {
        //public string CustomerCode { get; set; }
        //public string EncryptedPassword { get; set; }
        //public string privatekey { get; set; }
       
        //public JTExpressShipmentDegistBody()
        //{
        //    CustomerCode = JTExpressClientInfo.CustomerCode;
        //    EncryptedPassword=JTExpressClientInfo.EncryptedPassword;
        //    privatekey = JTExpressClientInfo.PrivateKey;


        //}
        public static string CalculateDigest()
        {
            string input = JTExpressClientInfo.CustomerCode + JTExpressClientInfo.EncryptedPassword  + JTExpressClientInfo.PrivateKey;
            string md5Hash = JTExpressHashUtility.CalculateMD5(input);
            string base64Digest = JTExpressHashUtility.CalculateBase64(md5Hash);
            return base64Digest;
        }

    }
}
