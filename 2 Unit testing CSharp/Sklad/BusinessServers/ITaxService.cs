using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Sklad
{
    public interface ITaxService
    {
        decimal GetTax(string regionCode, string productCode);
    }
}
