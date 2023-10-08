using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressHeader
    {
        public string apiAccount { get; set; }
        public string Timestemp { get; set; }
        public string DegistHeader { get; set; }

        public JTExpressHeader(string JsonBodyRequest)
        {
            apiAccount = JTExpressClientInfo.ApiAccount.ToString();
            Timestemp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(); ;

            //header degist
            //base64(md5(JsonBodyRequest+privatekey)
            var degist = JsonBodyRequest + JTExpressClientInfo.PrivateKey;
            var degistMd5 = JTExpressHashUtility.CalculateMD5(degist);
            var degistbase64 = JTExpressHashUtility.CalculateBase64(degistMd5);

            DegistHeader = degistbase64;
        }
    

  
}}
