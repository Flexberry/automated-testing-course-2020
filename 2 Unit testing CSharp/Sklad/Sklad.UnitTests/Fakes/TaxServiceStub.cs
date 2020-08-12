using IIS.Sklad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.UnitTests.Fakes
{
    class TaxServiceStub : ITaxService
    {
        public decimal GetTax(string regionCode, string productCode)
        {
            return 1.5m;
        }
    }
}
