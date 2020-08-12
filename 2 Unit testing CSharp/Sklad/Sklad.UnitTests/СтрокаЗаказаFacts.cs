using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using IIS.Sklad;
using Moq;
using Sklad.UnitTests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sklad.UnitTests
{    
    public class СтрокаЗаказаFacts
    {

        #region v1

        //[Fact]
        //[Trait("Module", "Billing")]
        //public void OnUpdateСтрокаЗаказа_Новая_ВычисляетЦенуСНалогом()
        //{
        //    // Arrange
        //    var строка = new СтрокаЗаказа
        //    {
        //        Количество = 1,
        //        Товар = new Товар
        //        {
        //            Цена = 100
        //        }
        //    };
        //    var бс = new ЗаказБС();

        //    // Act        
        //    бс.OnUpdateСтрокаЗаказа(строка);

        //    // Assert
        //    Assert.Equal(135, строка.ЦенаСНалогами);
        //}

        //[Fact]
        //[Trait("Module", "Billing")]
        //public void OnUpdateСтрокаЗаказа_Новая_ВычисляетСумму()
        //{
        //    // Arrange
        //    var строка = new СтрокаЗаказа
        //    {
        //        Количество = 2,
        //        Товар = new Товар
        //        {
        //            Цена = 100
        //        }
        //    };
        //    var бс = new ЗаказБС();

        //    // Act
        //    бс.OnUpdateСтрокаЗаказа(строка);

        //    // Assert
        //    Assert.Equal(270, строка.Сумма);
        //}

        #endregion

        #region v2
        //[Fact]
        //[Trait("Module", "Billing")]
        //public void OnUpdateСтрокаЗаказа_Новая_ВычисляетЦенуСНалогом()
        //{
        //    // Arrange
        //    var строка = new СтрокаЗаказа
        //    {
        //        Количество = 1,
        //        Товар = new Товар
        //        {
        //            Цена = 100
        //        },
        //        Заказ = new Заказ
        //        {
        //            Регион = new Регион
        //            {
        //                Код = "59"
        //            }
        //        }
        //    };
        //    var бс = new ЗаказБС();
        //    бс.TaxService = new TaxServiceStub();

        //    // Act
        //    бс.OnUpdateСтрокаЗаказа(строка);

        //    // Assert
        //    Assert.Equal(150, строка.ЦенаСНалогами);
        //}

        //[Fact]
        //[Trait("Module", "Billing")]
        //public void OnUpdateСтрокаЗаказа_Новая_ВычисляетСумму()
        //{
        //    // Arrange
        //    var строка = new СтрокаЗаказа
        //    {
        //        Количество = 2,
        //        Товар = new Товар
        //        {
        //            Цена = 100
        //        },
        //        Заказ = new Заказ
        //        {
        //            Регион = new Регион
        //            {
        //                Код = "59"
        //            }
        //        }
        //    };
        //    var бс = new ЗаказБС();
        //    бс.TaxService = new TaxServiceStub();

        //    // Act
        //    бс.OnUpdateСтрокаЗаказа(строка);

        //    // Assert
        //    Assert.Equal(300, строка.Сумма);
        //}
        #endregion

        #region v3

        private ЗаказБС бс;

        public СтрокаЗаказаFacts()
        {
            бс = new ЗаказБС();
            бс.TaxService = new TaxServiceStub();
        }

        [Fact]
        [Trait("Module", "Billing")]
        public void OnUpdateСтрокаЗаказа_Новая_ВычисляетЦенуСНалогом()
        {
            // Arrange
            var строка = new СтрокаЗаказа
            {
                Количество = 1,
                Товар = new Товар
                {
                    Цена = 100
                },
                Заказ = new Заказ
                {
                    Регион = new Регион
                    {
                        Код = "59"
                    }
                }
            };
            бс.DiscountService = Mock.Of<IDiscountService>();

            // Act
            бс.OnUpdateСтрокаЗаказа(строка);

            // Assert
            Assert.Equal(150, строка.ЦенаСНалогами);
        }

        [Fact]
        [Trait("Module", "Billing")]
        public void OnUpdateСтрокаЗаказа_Новая_ВычисляетСумму()
        {
            // Arrange
            var строка = new СтрокаЗаказа
            {
                Количество = 2,
                Товар = new Товар
                {
                    Цена = 100
                },
                Заказ = new Заказ
                {
                    Регион = new Регион
                    {
                        Код = "59"
                    }
                }
            };
            var discountServiceMock = new Mock<IDiscountService>();
            discountServiceMock
                .Setup(x => x.GetDiscount(It.IsAny<СтрокаЗаказа>()))
                .Returns(1m);
            бс.DiscountService = discountServiceMock.Object;

            // Act
            бс.OnUpdateСтрокаЗаказа(строка);

            // Assert
            Assert.Equal(300, строка.Сумма);
        }

        #endregion


        #region checks v1
        //[Fact]
        //public void OnUpdateСтрокаЗаказа_НоваяСНаличиемНаСкладе_УспешноВыполняется()
        //{
        //    // Arrange
        //    var товар = new Товар();
        //    var строка = new СтрокаЗаказа
        //    {
        //        Количество = 4,
        //        Товар = товар,
        //        Заказ = new Заказ
        //        {
        //            Регион = new Регион
        //            {
        //                Код = "59"
        //            }
        //        }
        //    };
        //    var товарыНаСкладе = new[]
        //    {
        //        new ТоварНаСкладе
        //        {
        //            Количество=3,
        //            Товар=товар
        //        },
        //        new ТоварНаСкладе
        //        {
        //            Количество=2,
        //            Товар=товар
        //        },
        //    };
        //    бс.DiscountService = Mock.Of<IDiscountService>();

        //    var dataServiceMock = new Mock<IDataService>();
        //    dataServiceMock.Setup(x => x.LoadObjects(It.Is<LoadingCustomizationStruct>(lcs => lcs.LoadingTypes.Contains(typeof(ТоварНаСкладе)))))
        //        .Returns(товарыНаСкладе);
        //    бс.DataService = dataServiceMock.Object;

        //    // Act
        //    бс.OnUpdateСтрокаЗаказа(строка);
        //}

        //[Fact]
        //public void OnUpdateСтрокаЗаказа_НоваяСНедостаткомНаСкладе_ГенерируетсяИсключение()
        //{
        //    // Arrange
        //    var товар = new Товар();
        //    var строка = new СтрокаЗаказа
        //    {
        //        Количество = 10,
        //        Товар = товар,
        //        Заказ = new Заказ
        //        {
        //            Регион = new Регион
        //            {
        //                Код = "59"
        //            }
        //        }
        //    };
        //    var товарыНаСкладе = new[]
        //    {
        //        new ТоварНаСкладе
        //        {
        //            Количество=3,
        //            Товар=товар
        //        },
        //        new ТоварНаСкладе
        //        {
        //            Количество=2,
        //            Товар=товар
        //        },
        //    };
        //    бс.DiscountService = Mock.Of<IDiscountService>();

        //    var dataServiceMock = new Mock<IDataService>();
        //    dataServiceMock.Setup(x => x.LoadObjects(It.Is<LoadingCustomizationStruct>(lcs => lcs.LoadingTypes.Contains(typeof(ТоварНаСкладе)))))
        //        .Returns(товарыНаСкладе);
        //    бс.DataService = dataServiceMock.Object;

        //    // Act
        //    var exception = Assert.Throws<Exception>(() => бс.OnUpdateСтрокаЗаказа(строка));

        //    // Assert
        //    Assert.Equal("Недостаточно товара на складах.", exception.Message);
        //}
        #endregion

        #region checks v2
        [Fact]
        public void OnUpdateСтрокаЗаказа_НоваяСНаличиемНаСкладе_УспешноВыполняется()
        {
            // Arrange
            var товар = new Товар();
            var строка = new СтрокаЗаказа
            {
                Количество = 4,
                Товар = товар,
                Заказ = new Заказ
                {
                    Регион = new Регион
                    {
                        Код = "59"
                    }
                }
            };
            бс.DiscountService = Mock.Of<IDiscountService>();
            бс.WarehouseService = Mock.Of<IWarehouseService>(ws => ws.CanReserveProduct(товар, 4) == true);

            // Act
            бс.OnUpdateСтрокаЗаказа(строка);
        }

        [Fact]
        public void OnUpdateСтрокаЗаказа_НоваяСНедостаткомНаСкладе_ГенерируетсяИсключение()
        {
            // Arrange
            var товар = new Товар();
            var строка = new СтрокаЗаказа
            {
                Количество = 10,
                Товар = товар,
                Заказ = new Заказ
                {
                    Регион = new Регион
                    {
                        Код = "59"
                    }
                }
            };
            бс.DiscountService = Mock.Of<IDiscountService>();
            бс.WarehouseService = Mock.Of<IWarehouseService>(ws => ws.CanReserveProduct(товар, 10) == false);

            // Act
            var exception = Assert.Throws<Exception>(() => бс.OnUpdateСтрокаЗаказа(строка));

            // Assert
            Assert.Equal("Недостаточно товара на складах.", exception.Message);
        }

        [Fact]
        public void OnUpdateСтрокаЗаказа_НоваяСНаличиемНаСкладе_ТоварыРезервируются()
        {
            // Arrange
            var товар = new Товар();
            var строка = new СтрокаЗаказа
            {
                Количество = 4,
                Товар = товар,
                Заказ = new Заказ
                {
                    Регион = new Регион
                    {
                        Код = "59"
                    }
                }
            };
            бс.DiscountService = Mock.Of<IDiscountService>();

            var whMock = new Mock<IWarehouseService>();
            whMock.Setup(x => x.CanReserveProduct(товар, 4)).Returns(true);
            бс.WarehouseService = whMock.Object;

            // Act
            бс.OnUpdateСтрокаЗаказа(строка);

            // Assert
            whMock.Verify(x => x.ReserveProduct(товар, 4));
        }
        #endregion
    }
}
