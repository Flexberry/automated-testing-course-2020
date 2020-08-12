using Iis.Eais.Common.TestFramework.Interfaces;
using Iis.Eais.Common.TestFramework.Services;
using Sklad.UnitTests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Xunit;

namespace Sklad.UnitTests
{
    public class EaisCommonTests
    {
        /// <summary>
        /// Тест <see cref="EaisTestRunner.Run" /> с сервисом тестирования модуля Sklad.
        /// </summary>
        [Fact(Skip ="not now")]        
        public void RunCommonTest()
        {
            // Arrange.
            var container = new UnityContainer();
            container.RegisterType<IEaisTestService, SkladCommonTestService>();
            var runner = new EaisTestRunner(container);

            // Act.
            runner.Run();
        }
    }
}
