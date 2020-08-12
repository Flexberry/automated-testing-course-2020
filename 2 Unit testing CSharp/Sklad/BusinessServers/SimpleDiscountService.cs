using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Sklad
{
    public class SimpleDiscountService : IDiscountService
    {
        public decimal GetDiscount(СтрокаЗаказа строкаЗаказа)
        {
            // логика вычисления скидки

            return строкаЗаказа.Количество > 5 ? 0.8m : 1;
        }
    }
}
