using ICSSoft.STORMNET.Business;
using Iis.Eais.Common.Interfaces;
using Iis.Eais.Common.TestFramework.Services;
using IIS.Sklad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sklad.UnitTests.Services
{
    public class SkladCommonTestService : EmptyEaisTestService
    {
        /// <inheritdoc />
        public override IEnumerable<Assembly> GetAssemblies()
        {
            return new List<Assembly> { typeof(Заказ).Assembly };
        }

        /// <inheritdoc />
        public override Type GetDataServiceType()
        {
            return typeof(PostgresDataService);
        }        

        /// <inheritdoc />
        public override void AssertTrue(bool condition, string userMessage)
        {
            Assert.True(condition, userMessage);
        }
    }
}
