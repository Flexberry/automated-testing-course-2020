using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Sklad
{
    public interface IWarehouseService
    {
        bool CanReserveProduct(Товар товар, int count);

        ТоварНаСкладе[] ReserveProduct(Товар товар, int count);
    }
}
