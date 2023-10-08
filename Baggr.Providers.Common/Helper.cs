using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Common
{
    public class Helper
    {
        public static string GenerateOrderRefrence()
        {
            string orderNumber = "";
            for (int i = 0; i < 10; i++)
            {
                orderNumber += new Random().Next(0, 10);
            }
            return orderNumber;
        }
    }
}
