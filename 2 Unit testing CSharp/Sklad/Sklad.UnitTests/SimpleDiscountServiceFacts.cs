using IIS.Sklad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sklad.UnitTests
{
    public class SimpleDiscountServiceFacts
    {
        [Fact]
        public void GetDiscount_РозничныйЗаказ_БезСкидки()
        {
            // Arrange
            var discountService = new SimpleDiscountService();
            var строкаЗаказа = new СтрокаЗаказа
            {
                Количество = 2
            };

            // Act
            var discount = discountService.GetDiscount(строкаЗаказа);

            // Assert
            Assert.Equal(1, discount);
        }

        [Fact]
        public void GetDiscount_ОптовыйЗаказ_Скидка20Процентов()
        {
            // Arrange
            var discountService = new SimpleDiscountService();
            var строкаЗаказа = new СтрокаЗаказа
            {
                Количество = 6
            };

            // Act
            var discount = discountService.GetDiscount(строкаЗаказа);

            // Assert
            Assert.Equal(0.8m, discount);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void GetDiscount_РозничныйЗаказ_БезСкидки_Theory(int count)
        {
            // Arrange
            var discountService = new SimpleDiscountService();
            var строкаЗаказа = new СтрокаЗаказа
            {
                Количество = count
            };

            // Act
            var discount = discountService.GetDiscount(строкаЗаказа);

            // Assert
            Assert.Equal(1, discount);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(100)]
        public void GetDiscount_ОптовыйЗаказ_Скидка20Процентов_Theory(int count)
        {
            // Arrange
            var discountService = new SimpleDiscountService();
            var строкаЗаказа = new СтрокаЗаказа
            {
                Количество = count
            };

            // Act
            var discount = discountService.GetDiscount(строкаЗаказа);

            // Assert
            Assert.Equal(0.8m, discount);
        }
    }
}
