using FundAppDomainTests.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppDomainTests.Tests
{
    [TestClass]
    public class StockWarningPolicyTests
    {
        #region Test methods

        [TestMethod]
        [TestCategory("domainTest")]
        public void StockWarningIsSignalledIfRequired()
        {
            InMemoryDomain.DoTest(rootDomainService =>
            {
                rootDomainService.StockEntitiesService.AddEquity(9999, 9999999);
                rootDomainService.StockEntitiesService.AddEquity(1, 1);


                var warningStock = rootDomainService.StockEntitiesService.ListStocks().Where(s => s.Name == "Equity1").First();
                var normalStock = rootDomainService.StockEntitiesService.ListStocks().Where(s => s.Name == "Equity2").First();


                Assert.IsTrue(warningStock.IsWarning);
                Assert.IsFalse(normalStock.IsWarning);
            });

        }

        #endregion
    }
}
