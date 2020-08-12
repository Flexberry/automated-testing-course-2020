using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.Sklad
{
    public class PersonalDiscountService : IDiscountService
    {
        public decimal GetDiscount(СтрокаЗаказа строкаЗаказа)
        {
            return IsVIP(строкаЗаказа.Заказ.Клиент) ? 0.75m : 1;
        }

        public bool IsVIP(Клиент клиент)
        {
            // логика определения важности клиента


            return клиент.Наименование.Contains("VIP");
        }
    }
}
