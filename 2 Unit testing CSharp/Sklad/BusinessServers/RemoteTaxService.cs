using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IIS.Sklad
{
    public class RemoteTaxService : ITaxService
    {
        public decimal GetTax(string regionCode, string productCode)
        {
            // remote call...
            Thread.Sleep(2000);

            return 1.2m;
        }
    }
}
