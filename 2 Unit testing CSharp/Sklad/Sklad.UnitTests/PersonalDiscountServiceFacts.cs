using IIS.Sklad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sklad.UnitTests
{
    public class PersonalDiscountServiceFacts
    {

        private static СтрокаЗаказа СоздатьСтрокуЗаказаКлиента(string имяКлиента)
        {
            return new СтрокаЗаказа
            {
                Заказ = new Заказ
                {
                    Клиент = new Клиент
                    {
                        Наименование = имяКлиента
                    }
                }
            };
        }

        public static IEnumerable<object[]> ОбычныеКлиенты = new List<object[]>
        {
            new[] { СоздатьСтрокуЗаказаКлиента("обычный клиент") },
            new[] { СоздатьСтрокуЗаказаКлиента("клиент еще обычнее") },
        };

        public static IEnumerable<object[]> ВипКлиенты = new List<object[]>
        {
            new[] { СоздатьСтрокуЗаказаКлиента("VIP клиент") },
            new[] { СоздатьСтрокуЗаказаКлиента("VIP VIP клиент") },
        };


        [Theory]
        [MemberData(nameof(ОбычныеКлиенты))]
        public void GetDiscount_ОбычныйКлиент_БезСкидки(СтрокаЗаказа строкаЗаказа)
        {
            // Arrange
            var discountService = new PersonalDiscountService();

            // Act
            var discount = discountService.GetDiscount(строкаЗаказа);

            // Assert
            Assert.Equal(1, discount);
        }

        [Theory]
        [MemberData(nameof(ВипКлиенты))]
        public void GetDiscount_ВипКлиент_Скидка20Процентов(СтрокаЗаказа строкаЗаказа)
        {
            // Arrange
            var discountService = new PersonalDiscountService();

            // Act
            var discount = discountService.GetDiscount(строкаЗаказа);

            // Assert
            Assert.Equal(0.75m, discount);
        }
    }
}
