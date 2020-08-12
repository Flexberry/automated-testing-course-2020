using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using IIS.Sklad;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sklad.UnitTests
{
    public class WarehouseServiceFacts
    {
        [Fact]
        public void ReserveProduct_ОдинТоварСБольшимОстатком_ОстатокУменьшается()
        {
            // Arrange
            var товарНаСкладе = new ТоварНаСкладе
            {
                Количество = 5
            };
            товарНаСкладе.InitDataCopy();

            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(x => x.LoadObjects(It.Is<LoadingCustomizationStruct>(lcs => lcs.LoadingTypes.Contains(typeof(ТоварНаСкладе)))))
                .Returns(new[] { товарНаСкладе });

            var whs = new WarehouseService(dataServiceMock.Object);

            // Act
            whs.ReserveProduct(new Товар(), 4);

            // Assert
            Assert.Equal(1, товарНаСкладе.Количество);
        }


        [Fact]
        public void ReserveProduct_ОдинТоварВНужномКоличестве_ТоварНаСкладеУдаляется()
        {
            // Arrange
            var товарНаСкладе = new ТоварНаСкладе
            {
                Количество = 4
            };
            товарНаСкладе.InitDataCopy();

            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(x => x.LoadObjects(It.Is<LoadingCustomizationStruct>(lcs => lcs.LoadingTypes.Contains(typeof(ТоварНаСкладе)))))
                .Returns(new[] { товарНаСкладе });

            var whs = new WarehouseService(dataServiceMock.Object);

            // Act
            whs.ReserveProduct(new Товар(), 4);

            // Assert
            Assert.Equal(ObjectStatus.Deleted, товарНаСкладе.GetStatus());
        }

        [Fact]
        public void ReserveProduct_ДваТовараВМеньшемКоличестве_ОдинТоварНаСкладеУдаляетсяВторойУменьшается()
        {
            // Arrange
            var товарНаСкладе1 = new ТоварНаСкладе
            {
                Количество = 2
            };
            товарНаСкладе1.InitDataCopy();

            var товарНаСкладе2 = new ТоварНаСкладе
            {
                Количество = 3
            };
            товарНаСкладе2.InitDataCopy();

            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(x => x.LoadObjects(It.Is<LoadingCustomizationStruct>(lcs => lcs.LoadingTypes.Contains(typeof(ТоварНаСкладе)))))
                .Returns(new[] { товарНаСкладе1, товарНаСкладе2 });

            var whs = new WarehouseService(dataServiceMock.Object);

            // Act
            whs.ReserveProduct(new Товар(), 4);

            // Assert
            Assert.Equal(ObjectStatus.Deleted, товарНаСкладе1.GetStatus());
            Assert.Equal(1, товарНаСкладе2.Количество);
        }
    }
}
